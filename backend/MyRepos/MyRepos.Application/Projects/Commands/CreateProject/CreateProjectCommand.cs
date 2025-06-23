using ErrorOr;
using MediatR;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(
        string RepositoryUrl) : IRequest<ErrorOr<Project>>;
}
