using FluentValidation;

namespace MyRepos.Application.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryValidator 
        : AbstractValidator<GetProjectByIdQuery>
    {
        public GetProjectByIdQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
