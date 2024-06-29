using Application.Dto.ApprovalRequests;

namespace Application.Interfaces;

public interface IApprovalRequestService
{
    Task<IEnumerable<ApprovalRequestDto>> GetAllApprovalRequestsAsync(string sortField, bool ascending, string filterBy);
    Task<ApprovalRequestDto> GetApprovalRequestByIdAsync(int id);
    Task<ApprovalRequestDto> AddApprovalRequestAsync(CreateApprovalRequestDto newApprovalRequest, string userId);
    Task UpdateApprovalRequestAsync(UpdateApprovalRequestDto updatedApprovalRequest);
    Task DeleteApprovalRequestAsync(int id);
}
