using Application.Dto.Employees;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{

    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> AddEmployeeAsync(CreateEmployeeDto employee)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployeeAsync(UpdateEmployeeDto employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }
}
