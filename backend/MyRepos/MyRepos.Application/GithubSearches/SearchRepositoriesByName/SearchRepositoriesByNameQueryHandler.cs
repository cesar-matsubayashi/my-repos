using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Application.Common.Services;
using MyRepos.Application.GithubSearches.SearchAllProjects;
using MyRepos.Domain.GithubRepositoryAggregate;
using MyRepos.Domain.GithubSearchAggregate;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.GithubSearches.SearchRepositoriesByName
{
    public class SearchRepositoriesByNameQueryHandler
        : IRequestHandler<SearchRepositoriesByNameQuery, ErrorOr<GithubSearch>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IGithubService _githubService;

        public SearchRepositoriesByNameQueryHandler(
            IGithubService githubService, 
            IProjectRepository projectRepository)
        {
            _githubService = githubService;
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<GithubSearch>> Handle(
            SearchRepositoriesByNameQuery request, 
            CancellationToken cancellationToken)
        {
            var favorites = await _projectRepository.GetAllFavoritesAsync();

            var githubSearch = await _githubService.GetAllGithubRepositoryByName(
                request.Keyword,
                request.Page);

            var repositories = githubSearch.Items.ConvertAll(
                repository => GithubRepository.Create(
                    repository.Id,
                    repository.Name,
                    repository.Description,
                    repository.Language,
                    repository.Updated_At,
                    repository.Owner.Login,
                    repository.Html_Url,
                    isFavorite(repository.Html_Url, favorites)));

            var search = GithubSearch.Create(githubSearch.Total_Count, repositories);

            return search;
        }

        public static bool isFavorite(string repositoryUrl, List<Project> favorites)
        {
            return favorites.Any(project => project.RepositoryUrl == repositoryUrl);
        }
    }
}
