using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System_Task.Commands.Employee;
using System_Task.Queries.Employee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace System_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateEmployeCommand> _validator;
        private readonly IValidator<UpdateEmployeCommand> _Updatevalidator;
        public EmployeeController(IMediator mediator, IValidator<CreateEmployeCommand> validator, IValidator<UpdateEmployeCommand> Updatevalidator)
        {
            _mediator = mediator;
            _validator = validator;
            _Updatevalidator = Updatevalidator;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get(string? query)
        {
            var cmd = new EmployeeAllQuery();
            cmd.query = query;
            if (User.IsInRole("Admin"))
                cmd.ForAdmin= true;
            return Ok(await _mediator.Send(cmd));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var cmd = new EmployeeGetByIdQuery();
            cmd.Id = id;
            var res = await _mediator.Send(cmd);
            if (res == null)
                return NotFound();
            return Ok (res);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeCommand command)
        {
            var validation = await _validator.ValidateAsync(command);
            if (validation.IsValid)
            {
                var res = await _mediator.Send(command);
                return Ok(res);
            }
          return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeCommand command)
        {
           var validation = await _Updatevalidator.ValidateAsync(command);
            if (validation.IsValid)
            {
                var res = await _mediator.Send(command);
                if (res == null)
                    return NotFound();
                return Ok(res);
            }
          return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cmd = new DeleteEmployeCommand();
            cmd.Id = id;
            await _mediator.Send(cmd);
            return NoContent();
        }
    }
}
