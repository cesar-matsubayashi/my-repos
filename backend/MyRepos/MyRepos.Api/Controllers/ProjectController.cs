using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRepos.Application.Projects.Commands.CreateProject;
using MyRepos.Application.Projects.Queries.GetProjectById;
using MyRepos.Contracts.Project;
using MyRepos.Domain.Project;

namespace MyRepos.Api.Controllers
{
    [Route("repositorio")]
    public class ProjectController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ProjectController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(
            CreateProjectRequest request)
        {
            var command = _mapper.Map<CreateProjectCommand>(request);
            var createProjectResult = await _mediator.Send(command);

            return createProjectResult.Match(
                project => Ok(_mapper.Map<ProjectResponse>(project)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProjectById(
            Guid id)
        {
            var query = _mapper.Map<GetProjectByIdQuery>(id);
            var getProjectQuery = await _mediator.Send(query);

            return getProjectQuery.Match(
                project => Ok(_mapper.Map<ProjectResponse>(project)),
                errors => Problem(errors));
        }
    }
}
