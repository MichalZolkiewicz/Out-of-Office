using Application.Dto.LeaveRequest;

namespace Application.Interfaces;

public interface ILeaveRequestService
{
    Task<IEnumerable<LeaveRequestDto>> GetAllApprovalRequestsAsync();
    Task<LeaveRequestDto> GetApprovalRequestsByIdAsync(int id);
    Task<LeaveRequestDto> AddApprovalRequestAsync(CreateLeaveRequestDto leaveRequest);
    Task UpdateApprovalRequestAsync(UpdateLeaveRequestDto leaveRequest);
    Task DeleteApprovalRequestAsync(int id);
}
