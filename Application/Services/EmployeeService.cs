using Application.Dto.Employee;
using Application.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    public Task<EmployeeDto> AddEmployeeAsync(CreateEmployeeDto employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployeeAsync(UpdateEmployeeDto employee)
    {
        throw new NotImplementedException();
    }
}
