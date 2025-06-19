using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Services;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Queries.SearchAllProjects
{
    public class SearchAllProjectsQueryHandler
        : IRequestHandler<SearchAllProjectsQuery, ErrorOr<List<Project>>>
    {
        private readonly IGithubServive _githubService;

        public SearchAllProjectsQueryHandler(IGithubServive githubService)
        {
            _githubService = githubService;
        }

        public async Task<ErrorOr<List<Project>>> Handle(
            SearchAllProjectsQuery request, 
            CancellationToken cancellationToken)
        {
            var metadata = await _githubService.GetAllRepositoryMetadataByName(
                request.Keyword,
                request.Page);

            var projects = metadata.Items.ConvertAll(
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
