using MyRepos.Domain.Common.Models;
using MyRepos.Domain.GithubRepositoryAggregate.ValueObjects;

namespace MyRepos.Domain.GithubRepositoryAggregate
{
    public class GithubRepository : AggregateRoot<GithubRepositoryId>
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? Language { get; private set; }
        public DateTimeOffset UpdatedDateTime { get; private set; }
        public string Owner { get; private set; }
        public string RepositoryUrl { get; private set; }
        public bool IsFavorite { get; private set; }

        private GithubRepository(
            GithubRepositoryId githubRepositoryId,
            string name,
            string description,
            string language,
            DateTimeOffset updatedDateTime,
            string owner,
            string repositoryUrl,
            bool isFavorite)
            : base(githubRepositoryId)
        {
            Name = name;
            Description = description;
            Language = language;
            UpdatedDateTime = updatedDateTime;
            Owner = owner;
            RepositoryUrl = repositoryUrl;
            IsFavorite = isFavorite;
        }

        public static GithubRepository Create(
            int githubRepositoryId,
            string name,
            string description,
            string language,
            DateTimeOffset updatedDateTime,
            string owner,
            string RepositoryUrl,
            bool isFavorite = false)
        {
            var repository = new GithubRepository(
                GithubRepositoryId.Create(githubRepositoryId),
                name,
                description,
                language,
                updatedDateTime,
                owner,
                RepositoryUrl,
                isFavorite);

            return repository;
        }
    }
}
