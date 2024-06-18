using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly OutOfOfficeContext _context;

    public EmployeeRepository(OutOfOfficeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        var createdEmployee = await _context.AddAsync(employee);
        await _context.SaveChangesAsync();
        return createdEmployee.Entity;
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}
