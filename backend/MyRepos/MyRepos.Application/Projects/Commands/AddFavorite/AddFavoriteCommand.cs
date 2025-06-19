using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;
using MyRepos.Domain.Project.ValueObjects;

namespace MyRepos.Application.Projects.Commands.AddFavorite
{
    public record AddFavoriteCommand(
        ProjectId Id) : IRequest<ErrorOr<Project>>;
}
