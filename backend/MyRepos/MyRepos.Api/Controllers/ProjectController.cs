using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRepos.Application.GithubSearches.SearchAllProjects;
using MyRepos.Application.Projects.Commands.ChangeFavorite;
using MyRepos.Application.Projects.Commands.CreateProject;
using MyRepos.Application.Projects.Commands.DeleteProject;
using MyRepos.Application.Projects.Commands.UpdateProject;
using MyRepos.Application.Projects.Queries.GetProjectById;
using MyRepos.Application.Projects.Queries.ListFavorites;
using MyRepos.Application.Projects.Queries.ListProject;
using MyRepos.Contracts.GithubSearch;
using MyRepos.Contracts.Project;
using MyRepos.Contracts.Project.Favorite;

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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProject(
            Guid id)
        {
            var command = _mapper.Map<DeleteProjectCommand>(id);
            var deleteProjectCommand = await _mediator.Send(command);

            return deleteProjectCommand.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }

        [HttpPatch("{id:guid}/favorito")]
        public async Task<IActionResult> AddFavoriteProject(
            ChangeFavoriteRequest request,
            Guid id)
        {
            var command = _mapper.Map<ChangeFavoriteCommand>((request, id));
            var changeFavoriteCommand = await _mediator.Send(command);

            return changeFavoriteCommand.Match(
                project => Ok(_mapper.Map<ProjectResponse>(project)),
                errors => Problem(errors));
        }

        [HttpGet("favoritos")]
        public async Task<IActionResult> ListFavorites()
        {
            var query = new ListFavoritesQuery();
            var listFavoritesQuery = await _mediator.Send(query);

            return listFavoritesQuery.Match(
                projects => Ok(_mapper.Map<List<ProjectResponse>>(projects)),
                errors => Problem(errors));
        }
    }
}
