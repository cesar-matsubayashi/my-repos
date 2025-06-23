using ErrorOr;
using MediatR;
using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Application.Projects.Commands.ChangeFavorite
{
    public record ChangeFavoriteCommand(
        ProjectId Id,
        bool IsFavorite) : IRequest<ErrorOr<Project>>;
}
