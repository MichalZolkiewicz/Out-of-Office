using Application.Dto.ApprovalRequests;
using Application.Interfaces;

namespace Application.Services;

public class ApprovalRequestService : IApprovalRequestService
{
    public Task<ApprovalRequestDto> AddApprovalRequestAsync(CreateApprovalRequestDto approvalRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteApprovalRequestAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ApprovalRequestDto>> GetAllApprovalRequestsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApprovalRequestDto> GetApprovalRequestByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateApprovalRequestAsync(UpdateApprovalRequestDto approvalRequest)
    {
        throw new NotImplementedException();
    }
}
