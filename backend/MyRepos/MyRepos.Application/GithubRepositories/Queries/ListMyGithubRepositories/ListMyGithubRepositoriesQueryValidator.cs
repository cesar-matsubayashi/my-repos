using FluentValidation;

namespace MyRepos.Application.GithubRepositories.Queries.ListMyGithubRepositories
{
    public class ListMyGithubRepositoriesQueryValidator
        : AbstractValidator<ListMyGithubRepositoriesQuery>
    {
        public ListMyGithubRepositoriesQueryValidator()
        {
            RuleFor(p => p.User).NotEmpty();
        }
    }
}
