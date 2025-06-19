using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;
using MyRepos.Domain.Project.ValueObjects;

namespace MyRepos.Application.Projects.Commands.ChangeFavorite
{
    public record ChangeFavoriteCommand(
        ProjectId Id,
        bool IsFavorite) : IRequest<ErrorOr<Project>>;
}
