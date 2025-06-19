using FluentValidation;

namespace MyRepos.Application.Projects.Queries.ListMyProjects
{
    public class ListMyProjectsQueryValidator
        : AbstractValidator<ListMyProjectsQuery>
    {
        public ListMyProjectsQueryValidator()
        {
            RuleFor(p => p.User).NotEmpty();
        }
    }
}
