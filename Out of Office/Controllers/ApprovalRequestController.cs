using Application.Dto.ApprovalRequests;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Out_of_Office.Filters;
using Out_of_Office.Filters.Helpers;
using Swashbuckle.AspNetCore.Annotations;

namespace Out_of_Office.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApprovalRequestController : ControllerBase
{
    private readonly IApprovalRequestService _approvalRequestService;

    public ApprovalRequestController(IApprovalRequestService approvalRequestService)
    {
        _approvalRequestService = approvalRequestService;
    }

    [SwaggerOperation(Summary = "Retireves sort fields")]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetApprovalRequestsSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Get list of all approval requests")]
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllApprovalRequestsAsync([FromQuery] ApprovalRequestSortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validSortingFilter = new ApprovalRequestSortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var approvalRequests = _approvalRequestService.GetAllApprovalRequestsAsync(validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
        if(approvalRequests == null)
        {
            return NotFound();
        }

        return Ok(approvalRequests);
    }

    [SwaggerOperation(Summary = "Retrieves approval request by id")]
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
    [HttpPost]
    public async Task<IActionResult> AddApprovalRequestAsync([FromBody] CreateApprovalRequestDto createApprovalRequest)
    {
        var approvalRequest = await _approvalRequestService.AddApprovalRequestAsync(createApprovalRequest);
        return Created($"api/approvalRequest/{approvalRequest.Id}", createApprovalRequest);
    }

    [SwaggerOperation(Summary = "Update approval request in database")]
    [HttpPut]
    public async Task<IActionResult> UpdateApprovalRequestAsync([FromBody] UpdateApprovalRequestDto updateApprovalRequest)
    {
        await _approvalRequestService.UpdateApprovalRequestAsync(updateApprovalRequest);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Remove approval request from database")]
    [HttpDelete]
    public async Task<IActionResult> DeleteApprovalRequestAsync([FromQuery] int id)
    {
        await _approvalRequestService.DeleteApprovalRequestAsync(id);
        return NoContent();
    }
}
