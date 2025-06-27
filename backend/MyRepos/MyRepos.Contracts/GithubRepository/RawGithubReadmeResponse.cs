namespace MyRepos.Contracts.GithubRepository
{
    public record RawGithubReadmeResponse(
        string Content,
        string Sha,
        string Html_Url,
        string Download_Url);
}
