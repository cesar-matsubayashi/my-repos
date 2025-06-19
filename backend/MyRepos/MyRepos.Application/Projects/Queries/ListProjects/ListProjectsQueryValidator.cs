using FluentValidation;

namespace MyRepos.Application.Projects.Queries.ListProject
{
    public class ListProjectsQueryValidator
        : AbstractValidator<ListProjectsQuery>
    {
        public ListProjectsQueryValidator() { }
    }
}
