using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.Common.Errors;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler
        : IRequestHandler<GetProjectByIdQuery, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<Project>> Handle(
            GetProjectByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if(project is null)
            {
                return Errors.Project.NotFound;
            }

            return project;
        }
    }
}
