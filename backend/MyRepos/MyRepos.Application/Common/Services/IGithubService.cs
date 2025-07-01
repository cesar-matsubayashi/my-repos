using MyRepos.Contracts.GithubRepository;
using MyRepos.Contracts.GithubSearch;

namespace MyRepos.Application.Common.Services
{
    public interface IGithubService
    {
        Task<RawGithubRepositoryResponse> GetGithubRepository(string url);
        Task<List<RawGithubRepositoryResponse>> GetAllGithubRepositoryByUser(string user);
        Task<RawGithubSearchResponse> GetAllGithubRepositoryByName(string name, int page);
        Task<RawGithubReadmeResponse> GetRepositoryReadme(string owner, string repositoryName);
    }
}
