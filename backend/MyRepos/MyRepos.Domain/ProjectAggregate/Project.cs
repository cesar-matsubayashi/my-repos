using MyRepos.Domain.Common.Models;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Domain.ProjectAggregate
{
    public sealed class Project : AggregateRoot<ProjectId>
    {
        public string Name { get; private set; }
        public int GithubId { get; private set; }
        public string? Description { get; private set; }
        public string? Language { get; private set; }
        public DateTimeOffset UpdatedDateTime { get; private set; }
        public string Owner {  get; private set; }
        public string RepositoryUrl { get; private set; }
        public bool IsFavorite { get; private set; }

        private Project(
            ProjectId repositoryId,
            int githubId,
            string name, 
            string description, 
            string language, 
            DateTimeOffset updatedDateTime, 
            string owner,
            string repositoryUrl)
            : base(repositoryId)
        {
            GithubId = githubId;
            Name = name;
            Description = description;
            Language = language;
            UpdatedDateTime = updatedDateTime;
            Owner = owner;
            RepositoryUrl = repositoryUrl;
        }

        public static Project Create(
            int githubId,
            string name,
            string description,
            string language,
            DateTimeOffset updatedDateTime,
            string owner,
            string RepositoryUrl)
        {
            var repository = new Project(
                ProjectId.CreateUnique(),
                githubId,
                name,
                description,
                language,
                updatedDateTime,
                owner,
                RepositoryUrl);

            return repository;
        }

        public void Update(
            string name,
            string description,
            string language,
            DateTimeOffset updatedDateTime,
            string owner,
            string repositoryUrl)
        {
            Name = name;
            Description = description;
            Language = language;
            UpdatedDateTime = updatedDateTime;
            Owner = owner;
            RepositoryUrl = repositoryUrl;
        }

        public void ChangeFavoriteStatus(bool status)
        {
            IsFavorite = status;
        }

#pragma warning disable CS8618
        private Project() { }
#pragma warning restore CS8618 
    }
}
