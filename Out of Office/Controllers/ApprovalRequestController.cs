using Application.Dto.ApprovalRequests;
using Application.Dto.LeaveRequests;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Out_of_Office.Filters;
using Out_of_Office.Filters.Helpers;
using Out_of_Office.Wrapper;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace Out_of_Office.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class ApprovalRequestController : ControllerBase
{
    private readonly IApprovalRequestService _approvalRequestService;
    private readonly IUserService _userService;
    private readonly ILeaveRequestService _leaveRequestService;
    private readonly UserManager<User> _userManager;

    public ApprovalRequestController(IApprovalRequestService approvalRequestService, IUserService userService, ILeaveRequestService leaveRequestService, UserManager<User> usermanager)
    {
        _approvalRequestService = approvalRequestService;
        _userService = userService;
        _leaveRequestService = leaveRequestService;
        _userManager = usermanager;
    }

    [SwaggerOperation(Summary = "Retireves sort fields")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetApprovalRequestsSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Get list of all approval requests")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllApprovalRequestsAsync([FromQuery] ApprovalRequestSortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validSortingFilter = new ApprovalRequestSortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var approvalRequests = await _approvalRequestService.GetAllApprovalRequestsAsync(validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
        if(approvalRequests == null)
        {
            return NotFound();
        }

        return Ok(approvalRequests);
    }

    [SwaggerOperation(Summary = "Retrieves approval request by id")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetApprovalRequestByIdAsync(int id)
    {
        var approvalRequest = await _approvalRequestService.GetApprovalRequestByIdAsync(id);
        if (approvalRequest == null)
        {
            return NotFound();
        }

        return Ok(approvalRequest);
    }

    [SwaggerOperation(Summary = "Add approval request to database")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpPost]
    public async Task<IActionResult> AddApprovalRequestAsync([FromBody] CreateApprovalRequestDto createApprovalRequest)
    {
        var approvalRequest = await _approvalRequestService.AddApprovalRequestAsync(createApprovalRequest, User.FindFirstValue(ClaimTypes.NameIdentifier));
        return Created($"api/approvalRequest/{approvalRequest.Id}", createApprovalRequest);
    }

    [SwaggerOperation(Summary = "Update approval request in database")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpPut]
    public async Task<IActionResult> UpdateApprovalRequestAsync([FromBody] UpdateApprovalRequestDto updateApprovalRequest)
    {
        if (updateApprovalRequest.Status == RequestStatus.Approved || updateApprovalRequest.Status == RequestStatus.Rejected)
        {
            var leaveRequest = new ChangeStatusLeaveRequestDto
            {
                Id = updateApprovalRequest.LeaveRequestId,
                Status = updateApprovalRequest.Status
            };
            await _leaveRequestService.ChangeStatusOfLeaveRequestAsync(leaveRequest);
        }
        else
        {
            return BadRequest(new Response(false, "Incorrect wording. Please use Approved or Rejected"));
        }

        await _approvalRequestService.UpdateApprovalRequestAsync(updateApprovalRequest);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Remove approval request from database")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpDelete]
    public async Task<IActionResult> DeleteApprovalRequestAsync([FromQuery] int id)
    {
        await _approvalRequestService.DeleteApprovalRequestAsync(id);
        return NoContent();
    }
}
