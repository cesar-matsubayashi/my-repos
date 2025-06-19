using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Services;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Queries.ListMyProjects
{
    public class ListMyProjectsQueryHandler
        : IRequestHandler<ListMyProjectsQuery, ErrorOr<List<Project>>>
    {
        private readonly IGithubService _githubService;

        public ListMyProjectsQueryHandler(
            IGithubService githubService)
        {
            _githubService = githubService;
        }

        public async Task<ErrorOr<List<Project>>> Handle(
            ListMyProjectsQuery request, 
            CancellationToken cancellationToken)
        {
            var metadata = await _githubService.GetAllRepositoryMetadataByUser(request.User);

            var projects = metadata.ConvertAll(
                project => Project.Create(
                    project.Name,
                    project.Description,
                    project.Language,
                    project.Updated_At,
                    project.Owner.Login,
                    project.Html_Url));

            return projects;
        }
    }
}
