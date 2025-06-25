using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Application.Common.Persistence
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
        Task<Project?> GetByIdAsync(ProjectId Id);
        Task<List<Project>> GetAllAsync();
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project); 
        Task<List<Project>> GetAllFavoritesAsync();
    }
}
