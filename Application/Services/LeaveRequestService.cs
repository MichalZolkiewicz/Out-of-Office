using Application.Dto.LeaveRequest;
using Application.Interfaces;

namespace Application.Services;

public class LeaveRequestService : ILeaveRequestService
{
    public Task<LeaveRequestDto> AddApprovalRequestAsync(CreateLeaveRequestDto leaveRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteApprovalRequestAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LeaveRequestDto>> GetAllApprovalRequestsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveRequestDto> GetApprovalRequestsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateApprovalRequestAsync(UpdateLeaveRequestDto leaveRequest)
    {
        throw new NotImplementedException();
    }
}
