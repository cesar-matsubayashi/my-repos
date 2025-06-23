using ErrorOr;
using MediatR;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Application.Projects.Queries.ListProject
{
    public class ListProjectsQueryHandler
        : IRequestHandler<ListProjectsQuery, ErrorOr<List<Project>>>
    {
        private readonly IProjectRepository _projectRepository;

        public ListProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<List<Project>>> Handle(
            ListProjectsQuery request, 
            CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            return projects;
        }
    }
}
