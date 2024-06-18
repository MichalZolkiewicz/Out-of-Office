using Domain.Entities;

namespace Domain.Interfaces;

public interface IApprovalRepository 
{
    Task<IEnumerable<ApprovalRequest>> GetAllAsync();
    Task<ApprovalRequest> GetByIdAsync(int id);
    Task<ApprovalRequest> AddAsync(ApprovalRequest approvalRequest);
    Task UpdateAsync(ApprovalRequest approvalRequest);
    Task DeleteAsync(ApprovalRequest approvalRequest);
}
