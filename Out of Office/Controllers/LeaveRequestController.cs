﻿using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Out_of_Office.Filters.Helpers;
using Out_of_Office.Filters;
using Swashbuckle.AspNetCore.Annotations;
using Application.Dto.LeaveRequests;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Application.Dto.ApprovalRequests;

namespace Out_of_Office.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{

    private readonly ILeaveRequestService _leaveRequestService;
    private readonly IApprovalRequestService _approveRequestService;
    private readonly IUserService _userService;

    public LeaveRequestController(ILeaveRequestService leaveRequestService, IApprovalRequestService approveRequestService, IUserService userService)
    {
        _leaveRequestService = leaveRequestService;
        _approveRequestService = approveRequestService;
        _userService = userService;
    }

    [SwaggerOperation(Summary = "Retireves sort fields")]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetLeaveRequestsSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Retrieves lists of all leave requests")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpGet]
    public async Task<IActionResult> GetAllLeaveRequestsAsync([FromQuery] LeaveRequestSortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validSortingFilter = new LeaveRequestSortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var leaveRequests = await _leaveRequestService.GetAllLeaveRequestsAsync(validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
        if (leaveRequests == null)
        {
            return NotFound();
        }

        return Ok(leaveRequests);
    }

    [SwaggerOperation(Summary = "Retrieves leave request by id")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLeaveRequestByIdAsync(int id)
    {
        var leaveRequest = await _leaveRequestService.GetLeaveRequestByIdAsync(id);
        if (leaveRequest == null)
        {
            return NotFound();
        }

        return Ok(leaveRequest);
    }

    [SwaggerOperation(Summary = "Add leave request to database")]
    [HttpPost]
    public async Task<IActionResult> AddLeaveRequestAsync([FromBody] CreateLeaveRequestDto createLeaveRequest)
    {
        var leaveRequest = await _leaveRequestService.AddLeaveRequestAsync(createLeaveRequest);
        var user = await _userService.GetUserByIdAsync(leaveRequest.UserId);

        var approvalRequest = new CreateApprovalRequestDto()
        {
            LeaveRequestId = leaveRequest.Id,
            ApproverId = user.PeoplePartnerId,
            Comment = "Awaiting approval",
            Status = "Awaiting approval"
        };

        await _approveRequestService.AddApprovalRequestAsync(approvalRequest);

        return Created($"api/leaveRequest/{leaveRequest.Id}", createLeaveRequest);
    }

    [SwaggerOperation(Summary = "Update leave request in database")]
    [HttpPut]
    public async Task<IActionResult> UpdateLeaveRequestAsync([FromBody] UpdateLeaveRequestDto updateLeaveRequest)
    {
        await _leaveRequestService.UpdateLeaveRequestAsync(updateLeaveRequest);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Remove leave request from database")]
    [HttpDelete]
    public async Task<IActionResult> DeleteLeaveRequestAsync([FromQuery] int id)
    {
        await _leaveRequestService.DeleteLeaveRequestAsync(id);
        return NoContent();
    }
}
