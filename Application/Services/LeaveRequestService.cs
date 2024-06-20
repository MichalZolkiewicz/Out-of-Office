using Application.Dto.LeaveRequests;
using Application.Interfaces;

namespace Application.Services;

public class LeaveRequestService : ILeaveRequestService
{
    public Task<LeaveRequestDto> AddLeaveRequestAsync(CreateLeaveRequestDto leaveRequest)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLeaveRequestAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LeaveRequestDto>> GetAllLeaveRequestsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveRequestDto> GetLeaveRequestByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLeaveRequestAsync(UpdateLeaveRequestDto leaveRequest)
    {
        throw new NotImplementedException();
    }
}
