using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.Common.Errors;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler
        : IRequestHandler<UpdateProjectCommand, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<Project>> Handle(
            UpdateProjectCommand request, 
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project is null)
            {
                return Errors.Project.NotFound;
            }

            project.Update(
                request.Name,
                request.Description,
                request.Language,
                request.UpdatedDateTime,
                request.Owner,
                request.RepositoryUrl);

            await _projectRepository.UpdateAsync(project);

            return project;
        }
    }
}
