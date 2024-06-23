using Application.Dto.ApprovalRequests;

namespace Application.Interfaces;

public interface IApprovalRequestService
{
    Task<IEnumerable<ApprovalRequestDto>> GetAllApprovalRequestsAsync();
    Task<ApprovalRequestDto> GetApprovalRequestByIdAsync(int id);
    Task<ApprovalRequestDto> AddApprovalRequestAsync(CreateApprovalRequestDto newApprovalRequest);
    Task UpdateApprovalRequestAsync(UpdateApprovalRequestDto updatedApprovalRequest);
    Task DeleteApprovalRequestAsync(int id);
}
