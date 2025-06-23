using MyRepos.Contracts.GithubRepository;

namespace MyRepos.Application.Common.Services
{
    public interface IGithubService
    {
        Task<RawGithubRepositoryResponse> GetGithubRepository(string url);
        Task<List<RawGithubRepositoryResponse>> GetAllGithubRepositoryByUser(string user);
        Task<GithubSearchResponse> GetAllGithubRepositoryByName(string name, int page);
    }
}
