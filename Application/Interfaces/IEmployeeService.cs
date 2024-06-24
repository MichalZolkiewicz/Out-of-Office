using Application.Dto.Employees;

namespace Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string sortField, bool ascending, string filterBy);
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> AddEmployeeAsync(CreateEmployeeDto newEmployee);
    Task UpdateEmployeeAsync(UpdateEmployeeDto updatedEmployee);
    Task DeleteEmployeeAsync(int id);
}
