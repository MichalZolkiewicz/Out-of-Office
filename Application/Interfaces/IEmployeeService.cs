using Application.Dto.Employee;

namespace Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllApprovalRequestsAsync();
    Task<EmployeeDto> GetApprovalRequestsByIdAsync(int id);
    Task<EmployeeDto> AddApprovalRequestAsync(CreateEmployeeDto employee);
    Task UpdateApprovalRequestAsync(UpdateEmployeeDto employee);
    Task DeleteApprovalRequestAsync(int id);
}
