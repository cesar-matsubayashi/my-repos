using ErrorOr;
using MediatR;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Application.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand(ProjectId Id) : IRequest<ErrorOr<Deleted>>;
}
