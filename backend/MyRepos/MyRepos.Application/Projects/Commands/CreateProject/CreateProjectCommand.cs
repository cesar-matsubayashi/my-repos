using ErrorOr;
using MediatR;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(
        string RepositoryUrl) : IRequest<ErrorOr<Project>>;
}
