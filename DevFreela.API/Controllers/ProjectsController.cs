using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetByIdProjects;
using DevFreela.Application.Queries.GetProjectComments;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Authorize]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediatR)
        {
            _mediator = mediatR;
        }

        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get()
        {
            GetAllProjectsQuery request = new GetAllProjectsQuery();
            List<ProjectViewModel> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdProjectsQuery request = new GetByIdProjectsQuery(id);
            Project response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand request)
        {

            int idProjeto = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetById), new { id = idProjeto }, request);
        }

        [HttpPut]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand request)
        {

            await _mediator.Send(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProjectCommand request = new DeleteProjectCommand(id);

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> CreateComment(int id, CreateCommentCommand request)
        {

            await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("{id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetComment(int id)
        {
            GetProjectCommentsQuery command = new GetProjectCommentsQuery(id);
            List<ProjectComment> result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            StartProjectCommand resquest = new StartProjectCommand(id);
            await _mediator.Send(resquest);

            return Ok();
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id)
        {
            FinishProjectCommand request = new FinishProjectCommand(id);
            await _mediator.Send(request);

            return Ok();
        }
    }
}
