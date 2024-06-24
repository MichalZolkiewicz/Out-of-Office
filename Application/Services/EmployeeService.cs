using Application.Dto.Employees;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{

    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(string sortField, bool ascending, string filterBy)
    {
        var employee = await _employeeRepository.GetAllAsync(sortField, ascending, filterBy);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employee);
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> AddEmployeeAsync(CreateEmployeeDto newEmployee)
    {
        var employee = _mapper.Map<Employee>(newEmployee);
        var result = await _employeeRepository.AddAsync(employee);
        return _mapper.Map<EmployeeDto>(result);
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployee)
    {
        var existingEmployee = await _employeeRepository.GetByIdAsync(updateEmployee.Id);
        var employee = _mapper.Map(updateEmployee, existingEmployee);
        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var post = await _employeeRepository.GetByIdAsync(id);
        await _employeeRepository.DeleteAsync(post);
    }
}
