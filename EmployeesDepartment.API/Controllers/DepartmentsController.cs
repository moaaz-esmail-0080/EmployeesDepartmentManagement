using EmplDepartApplication.Commands.Department;
using EmplDepartApplication.DTOs;
using EmplDepartApplication.Queries.Department;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesDepartment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> GetDepartments()
        {
            var query = new GetDepartmentsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var department = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentId = id });
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            var departmentId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDepartment), new { id = departmentId }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentCommand command)
        {
            if (id != command.DepartmentId)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _mediator.Send(new DeleteDepartmentCommand { DepartmentId = id });
            return NoContent();
        }
    }

}
