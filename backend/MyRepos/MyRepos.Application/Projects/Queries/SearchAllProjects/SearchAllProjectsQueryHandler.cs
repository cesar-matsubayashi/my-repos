using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Services;
using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.Search;

namespace MyRepos.Application.Projects.Queries.SearchAllProjects
{
    public class SearchAllProjectsQueryHandler
        : IRequestHandler<SearchAllProjectsQuery, ErrorOr<SearchResult>>
    {
        private readonly IGithubService _githubService;

        public SearchAllProjectsQueryHandler(IGithubService githubService)
        {
            _githubService = githubService;
        }

        public async Task<ErrorOr<SearchResult>> Handle(
            SearchAllProjectsQuery request, 
            CancellationToken cancellationToken)
        {
            var metadata = await _githubService.GetAllGithubRepositoryByName(
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

            var search = SearchResult.Create(metadata.Total_Count, projects);

            return search;
        }
    }
}
