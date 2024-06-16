using DevFreela.API.Models;
using DevFreela.Application.Commands.ActiveUser;
using DevFreela.Application.Commands.CreateFreelancerUser;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.DeleteSkillUser;
using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id) {

            GetUserQuery request = new GetUserQuery(id);
            User response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("Active")]
        public async Task<IActionResult> PostActive(ActiveUserCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        {
            if (!ModelState.IsValid)
            {
                List<string> messages = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(messages);
            }

            int identificador = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetById), new { id = identificador }, request);
        }

        [HttpPost("Freelancer")]
        public async Task<IActionResult> PostFreelancer([FromBody] CreateFreelancerUserCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{id}/Skill/{idSkill}")]
        public async Task<IActionResult> DeleteSkill(int id, int idSkill)
        {
            DeleteSkillUserCommand request = new DeleteSkillUserCommand(id, idSkill);
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
