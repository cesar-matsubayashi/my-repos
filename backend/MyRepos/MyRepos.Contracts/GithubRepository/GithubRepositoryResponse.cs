
namespace MyRepos.Contracts.GithubRepository
{
    public record GithubRepositoryResponse(
        int GithubId,
        string Name,
        string Description,
        string Language,
        DateTimeOffset UpdatedDateTime,
        string Owner,
        string RepositoryUrl,
        bool IsFavorite);
}
