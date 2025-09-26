using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetStudentList")]
        public async Task<IActionResult> GetStudentsList(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetStudentListQuery(), cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("GetStudent")]
        public async Task<IActionResult> GetStudentbyId([FromQuery] int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery() { Id = id }, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand addStudentCommand, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(addStudentCommand, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
    }
}
