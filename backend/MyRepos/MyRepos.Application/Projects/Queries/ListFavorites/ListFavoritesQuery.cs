using ErrorOr;
using MediatR;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.Projects.Queries.ListFavorites
{
    public record ListFavoritesQuery() : IRequest<ErrorOr<List<Project>>>;
}
