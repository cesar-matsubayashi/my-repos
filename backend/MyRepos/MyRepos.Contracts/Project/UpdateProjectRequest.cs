namespace MyRepos.Contracts.Project
{
    public record UpdateProjectRequest(
        string Name,
        string Description,
        string Language,
        DateTimeOffset UpdatedDateTime,
        string Owner,
        string RepositoryUrl);
}
