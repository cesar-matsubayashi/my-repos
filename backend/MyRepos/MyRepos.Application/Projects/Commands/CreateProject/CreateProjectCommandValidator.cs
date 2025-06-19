using FluentValidation;

namespace MyRepos.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : 
        AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p =>  p.RepositoryUrl).NotEmpty();
        }
    }
}
