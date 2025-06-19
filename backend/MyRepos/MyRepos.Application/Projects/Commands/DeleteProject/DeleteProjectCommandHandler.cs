using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.Common.Errors;

namespace MyRepos.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler
        : IRequestHandler<DeleteProjectCommand, ErrorOr<Deleted>>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(
            DeleteProjectCommand request, 
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project is null)
            {
                return Errors.Project.NotFound;
            }

            await _projectRepository.DeleteAsync(project);

            return new Deleted();
        }
    }
}
