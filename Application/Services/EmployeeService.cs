using Application.Dto.Employee;
using Application.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    public Task<EmployeeDto> AddApprovalRequestAsync(CreateEmployeeDto employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteApprovalRequestAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmployeeDto>> GetAllApprovalRequestsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> GetApprovalRequestsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateApprovalRequestAsync(UpdateEmployeeDto employee)
    {
        throw new NotImplementedException();
    }
}
