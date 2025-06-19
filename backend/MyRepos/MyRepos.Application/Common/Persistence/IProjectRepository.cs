using MyRepos.Domain.Project;

namespace MyRepos.Application.Common.Persistence
{
    public interface IProjectRepository
    {
        Task AddAsync(Project project);
    }
}
