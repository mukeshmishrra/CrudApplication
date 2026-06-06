using CrudAppliction.Models.Dtos;
using CrudAppliction.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAppliction.Controllers
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



        // Get all employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employeeResponse = await _employeeService.GetAllEmployeeAsync();
            return Ok(employeeResponse);
        }


        // Get employee by id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employeeResponse = await _employeeService.GetEmployeeByIdAsync(id);
            if (employeeResponse == null)
            {
                return NotFound();
            }
            return Ok(employeeResponse);
        }


        // create new employee

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto empFormRequest) {
            var createdReq = await _employeeService.CreateEmployeeAsync(empFormRequest);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdReq.EmpId }, createdReq);
        }

        // update employee

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeCreateDto updateFormRequest)
        { 
            var updatedResult = await _employeeService.UpdateEmployeeAsync(id, updateFormRequest);

            if (updatedResult == null) {
                return NotFound("Invalid request");
            }

            return Ok(updatedResult);

        }

        // delete employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteteEmployee(int id)
        {
           var deleteResult = await _employeeService.DeleteEmployeeAsync(id);
            if (!deleteResult)
            {
                return NotFound();
            }
            return Ok($"Employee Id: {id} is deleted successfully!!");
        }

    }
}
