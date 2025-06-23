using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.Common.Errors;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.Projects.Commands.ChangeFavorite
{
    public class ChangeFavoriteCommandHandler
        : IRequestHandler<ChangeFavoriteCommand, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public ChangeFavoriteCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<Project>> Handle(
            ChangeFavoriteCommand request, 
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project is null)
            {
                return Errors.Project.NotFound;
            }

            project.ChangeFavoriteStatus(request.IsFavorite);

            await _projectRepository.UpdateAsync(project);

            return project;
        }
    }
}
