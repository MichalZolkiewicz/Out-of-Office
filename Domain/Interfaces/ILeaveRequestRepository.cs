using Domain.Entities;

namespace Domain.Interfaces;

public interface ILeaveRequestRepository
{
    Task<IEnumerable<LeaveRequest>> GetAllAsync();
    Task<LeaveRequest> GetByIdAsync(int id);
    Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest);
    Task UpdateAsync(LeaveRequest leaveRequest);
    Task DeleteAsync(LeaveRequest leaveRequest);
}
