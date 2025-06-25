using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Application.Common.Services;
using MyRepos.Domain.GithubRepositoryAggregate;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.GithubRepositories.Queries.ListMyGithubRepositories
{
    public class ListMyGithubRepositoriesQueryHandler
        : IRequestHandler<ListMyGithubRepositoriesQuery, ErrorOr<List<GithubRepository>>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IGithubService _githubService;

        public ListMyGithubRepositoriesQueryHandler(
            IGithubService githubService, 
            IProjectRepository projectRepository)
        {
            _githubService = githubService;
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<List<GithubRepository>>> Handle(
            ListMyGithubRepositoriesQuery request, 
            CancellationToken cancellationToken)
        {
            var favorites = await _projectRepository.GetAllFavoritesAsync();
            var githubRepositories = await _githubService.GetAllGithubRepositoryByUser(request.User);



            var myProjects = githubRepositories.ConvertAll(
                repository => GithubRepository.Create(
                    repository.Id,
                    repository.Name,
                    repository.Description,
                    repository.Language,
                    repository.Updated_At,
                    repository.Owner.Login,
                    repository.Html_Url,
                    isFavorite(repository.Html_Url, favorites)));

            return myProjects;
        }

        public static bool isFavorite(string repositoryUrl, List<Project> favorites)
        {
            return favorites.Any(project => project.RepositoryUrl == repositoryUrl);
        }
    }
}
