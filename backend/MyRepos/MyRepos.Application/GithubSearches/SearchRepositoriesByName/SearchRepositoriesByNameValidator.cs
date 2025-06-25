using FluentValidation;

namespace MyRepos.Application.GithubSearches.SearchAllProjects
{
    public class SearchRepositoriesByNameValidator
        : AbstractValidator<SearchRepositoriesByNameQuery>
    {
        public SearchRepositoriesByNameValidator()
        {
            RuleFor(s => s.Keyword).NotEmpty();
        }
    }
}
