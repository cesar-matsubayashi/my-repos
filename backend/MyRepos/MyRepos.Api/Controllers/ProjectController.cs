using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRepos.Application.Projects.Commands.CreateProject;
using MyRepos.Application.Projects.Commands.UpdateProject;
using MyRepos.Application.Projects.Queries.GetProjectById;
using MyRepos.Application.Projects.Queries.ListProject;
using MyRepos.Contracts.Project;

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

        [HttpGet]
        public async Task<IActionResult> ListProjects()
        {
            var query = new ListProjectsQuery();
            var listProjectQuery = await _mediator.Send(query);

            return listProjectQuery.Match(
                projects => Ok(_mapper.Map<List<ProjectResponse>>(projects)),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProject(
            UpdateProjectRequest request,
            Guid id)
        {
            var command = _mapper.Map<UpdateProjectCommand>((request, id));
            var updateProjectCommand = await _mediator.Send(command);

            return updateProjectCommand.Match(
                project => Ok(_mapper.Map<ProjectResponse>(project)),
                errors => Problem(errors));
        }
    }
}
