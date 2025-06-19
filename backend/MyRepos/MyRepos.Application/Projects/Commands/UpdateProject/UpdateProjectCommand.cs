using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;
using MyRepos.Domain.Project.ValueObjects;

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
