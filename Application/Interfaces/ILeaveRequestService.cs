using Application.Dto.LeaveRequest;

namespace Application.Interfaces;

public interface ILeaveRequestService
{
    Task<IEnumerable<LeaveRequestDto>> GetAllLeaveRequestsAsync();
    Task<LeaveRequestDto> GetLeaveRequestByIdAsync(int id);
    Task<LeaveRequestDto> AddLeaveRequestAsync(CreateLeaveRequestDto leaveRequest);
    Task UpdateLeaveRequestAsync(UpdateLeaveRequestDto leaveRequest);
    Task DeleteLeaveRequestAsync(int id);
}
