using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task<Employee> AddAsync(Employee employee);
    Task<Employee> UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
}
