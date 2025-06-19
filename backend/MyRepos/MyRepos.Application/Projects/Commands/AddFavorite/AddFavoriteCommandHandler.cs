using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.Common.Errors;
using MyRepos.Domain.Project;

namespace MyRepos.Application.Projects.Commands.AddFavorite
{
    public class AddFavoriteCommandHandler
        : IRequestHandler<AddFavoriteCommand, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public AddFavoriteCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<Project>> Handle(
            AddFavoriteCommand request, 
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project is null)
            {
                return Errors.Project.NotFound;
            }

            project.AddToFavorite();

            await _projectRepository.UpdateAsync(project);

            return project;
        }
    }
}
