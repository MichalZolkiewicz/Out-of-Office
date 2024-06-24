using Domain.Entities;

namespace Domain.Interfaces;

public interface ILeaveRequestRepository
{
    Task<IEnumerable<LeaveRequest>> GetAllAsync(string sortField, bool ascending, string filterBy);
    Task<LeaveRequest> GetByIdAsync(int id);
    Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest);
    Task UpdateAsync(LeaveRequest leaveRequest);
    Task DeleteAsync(LeaveRequest leaveRequest);
}
