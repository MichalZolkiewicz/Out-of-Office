using Application.Dto.Employee;

namespace Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> AddEmployeeAsync(CreateEmployeeDto employee);
    Task UpdateEmployeeAsync(UpdateEmployeeDto employee);
    Task DeleteEmployeeAsync(int id);
}
