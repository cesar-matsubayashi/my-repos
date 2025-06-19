using FluentValidation;

namespace MyRepos.Application.Projects.Queries.SearchAllProjects
{
    public class SearchAllProjectsQueryValidator
        : AbstractValidator<SearchAllProjectsQuery>
    {
        public SearchAllProjectsQueryValidator()
        {
            RuleFor(s => s.Keyword).NotEmpty();
        }
    }
}
