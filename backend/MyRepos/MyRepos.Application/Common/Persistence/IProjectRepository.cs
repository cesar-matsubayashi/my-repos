using MyRepos.Domain.Project;
using MyRepos.Domain.Project.ValueObjects;

namespace MyRepos.Application.Common.Persistence
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task<Project?> GetByIdAsync(ProjectId Id);
        Task<List<Project>> GetAllAsync();

    }
}
