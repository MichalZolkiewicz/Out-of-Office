using Application.Dto.Employees;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Out_of_Office.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [SwaggerOperation(Summary = "Retrieves lists of all employees")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            if(employees == null)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [SwaggerOperation(Summary = "Retrieves employee by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [SwaggerOperation(Summary = "Add employee to database")]
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] CreateEmployeeDto createEmployee)
        {
            var employee = await _employeeService.AddEmployeeAsync(createEmployee);
            return Created($"api/employee/{employee.Id}", createEmployee);
        }

        [SwaggerOperation(Summary = "Update employee in database")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] UpdateEmployeeDto updateEmployee)
        {
            await _employeeService.UpdateEmployeeAsync(updateEmployee);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Remove employee from database")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeAsync([FromQuery] int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
