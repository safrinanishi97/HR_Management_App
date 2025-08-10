using HRMApp.Application.Commands.CreateEmployee;
using HRMApp.Application.Commands.DeleteEmployee;
using HRMApp.Application.Commands.UpdateEmployee;
using HRMApp.Application.DTOs;
using HRMApp.Application.Queries.GetAllEmployee;
using HRMApp.Application.Queries.GetEmployeeById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMApp.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees([FromQuery] int idClient, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery(idClient), cancellationToken);
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] int idClient,int id, CancellationToken cancellationToken)
        {
    
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(idClient, id), cancellationToken);
            if (employee == null) return NotFound();
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employeeId = await _mediator.Send(command, cancellationToken);
            return Ok(employeeId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromForm] UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employeeId = await _mediator.Send(command, cancellationToken);
            return Ok(employeeId);
        }

        [HttpDelete("{idClient}/{id}")]
        public async Task<IActionResult> DeleteEmployee(int idClient, int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new SoftDeleteEmployeeCommand(idClient, id), cancellationToken);

            if (!result)
            {
                return NotFound("Employee not found.");
            }

            return Ok(new { message = "Employee soft deleted successfully." });
        }

    }
}
