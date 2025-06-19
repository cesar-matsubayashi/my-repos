using ErrorOr;
using MediatR;
using MyRepos.Domain.Project.ValueObjects;

namespace MyRepos.Application.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand(ProjectId Id) : IRequest<ErrorOr<Deleted>>;
}
