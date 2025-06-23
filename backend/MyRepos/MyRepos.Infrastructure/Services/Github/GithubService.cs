using MyRepos.Application.Common.Services;
using MyRepos.Contracts.GithubRepository;
using System.Text.Json;

namespace MyRepos.Infrastructure.Services.Github
{
    public class GithubService : IGithubService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;
        private const string BaseUrl = "https://api.github.com";

        public GithubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public (string Owner, string Repo) ParseGithubUrl(string url)
        {
            var uri = new Uri(url);
            var segments = uri.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length >= 2)
            {
                var owner = segments[0];
                var repo = segments[1];
                return (owner, repo);
            }

            throw new ArgumentException("Invalid GitHub repository URL.");
        }

        public async Task<RawGithubRepositoryResponse> GetGithubRepository(string url)
        {
            try
            {
                var (owner, repo) = ParseGithubUrl(url);
                var response = await _httpClient.GetAsync($"{BaseUrl}/repos/{owner}/{repo}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RawGithubRepositoryResponse>(json, _jsonOptions);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to get repository metadata: {ex.Message}", ex);
            }
        }

        public async Task<List<RawGithubRepositoryResponse>> GetAllGithubRepositoryByUser(string user)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/users/{user}/repos");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<RawGithubRepositoryResponse>>(json, _jsonOptions);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to get repository metadata: {ex.Message}", ex);
            }
        }

        public async Task<GithubSearchResponse> GetAllGithubRepositoryByName(string name, int page = 1)
        {
            try
            {
                int perPage = 10;
                var response = await _httpClient.GetAsync($"{BaseUrl}/search/repositories?" +
                    $"q={name} in:name" +
                    $"&page={page}" +
                    $"&per_page={perPage}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<GithubSearchResponse>(json, _jsonOptions);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to get repository metadata: {ex.Message}", ex);
            }
        }
    }
}
