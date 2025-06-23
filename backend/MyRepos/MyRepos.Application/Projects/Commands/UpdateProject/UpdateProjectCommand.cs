using ErrorOr;
using MediatR;
using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Application.Projects.Commands.UpdateProject
{
    public record UpdateProjectCommand(
        ProjectId Id,
        string Name,
        string Description,
        string Language,
        DateTimeOffset UpdatedDateTime,
        string Owner,
        string RepositoryUrl) : IRequest<ErrorOr<Project>>;
}
