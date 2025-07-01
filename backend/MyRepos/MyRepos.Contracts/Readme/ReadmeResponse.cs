namespace MyRepos.Contracts.Readme
{
    public record ReadmeResponse(
        string Content,
        string Encoding,
        string Sha,
        string Url,
        string DownloadUrl);
}