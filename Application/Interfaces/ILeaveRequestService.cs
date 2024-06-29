using Application.Dto.LeaveRequests;

namespace Application.Interfaces;

public interface ILeaveRequestService
{
    Task<IEnumerable<LeaveRequestDto>> GetAllLeaveRequestsAsync(string sortField, bool ascending, string filterBy);
    Task<LeaveRequestDto> GetLeaveRequestByIdAsync(int id);
    Task<LeaveRequestDto> AddLeaveRequestAsync(CreateLeaveRequestDto newLeaveRequest);
    Task UpdateLeaveRequestAsync(UpdateLeaveRequestDto updatedLeaveRequest);
    Task DeleteLeaveRequestAsync(int id);
    Task ChangeStatusOfLeaveRequestAsync(ChangeStatusLeaveRequestDto changeStatusLeaveRequest);
}
