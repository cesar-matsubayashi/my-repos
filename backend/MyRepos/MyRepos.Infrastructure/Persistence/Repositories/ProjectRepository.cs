using MyRepos.Application.Common.Persistence;
using MyRepos.Domain.Project;

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
    }
}
