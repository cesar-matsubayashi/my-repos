using Microsoft.EntityFrameworkCore;
using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly MyReposDbContext _dbContext;

        public ProjectRepository(MyReposDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            _dbContext.Remove(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<List<Project>> GetAllFavoritesAsync()
        {
            return await _dbContext.Projects
                .Where(p => p.IsFavorite == true)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(ProjectId Id)
        {
            return await _dbContext.Projects.FindAsync(Id);
        }

        public async Task UpdateAsync(Project project)
        {
            _dbContext.Projects.Update(project);
            await _dbContext.SaveChangesAsync();
        }
    }
}
