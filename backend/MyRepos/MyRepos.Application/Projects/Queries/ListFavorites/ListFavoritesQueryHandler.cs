using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.Projects.Queries.ListFavorites
{
    public class ListFavoritesQueryHandler
        : IRequestHandler<ListFavoritesQuery, ErrorOr<List<Project>>>
    {
        private readonly IProjectRepository _projectRepository;

        public ListFavoritesQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<List<Project>>> Handle(
            ListFavoritesQuery request, 
            CancellationToken cancellationToken)
        {
            var favorites = await _projectRepository.GetAllFavoritesAsync();

            return favorites;
        }
    }
}
