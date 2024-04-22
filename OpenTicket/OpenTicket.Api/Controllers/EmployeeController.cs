using Microsoft.AspNetCore.Mvc;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Domain.Handlers;

namespace OpenTicket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeHandler _employeeHandler;

        public EmployeeController(EmployeeHandler employeeHandler)
        {
            _employeeHandler = employeeHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(SaveEmployeeCommand command)
        {
            var result = await _employeeHandler.SaveEmployeeAsync(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeHandler.GetAllEmployeesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeHandler.GetEmployeeByIdAsync(id);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("O ID do funcionário na URL não corresponde ao ID fornecido no comando.");
            }

            var result = await _employeeHandler.UpdateEmployeeAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            var result = await _employeeHandler.DeleteEmployeeAsync(command);
            return Ok(result);
        }
    }
}
