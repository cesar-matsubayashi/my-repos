using FluentValidation;

namespace MyRepos.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectValidator
        : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Language).NotEmpty();
            RuleFor(p => p.UpdatedDateTime).NotEmpty();
            RuleFor(p => p.Owner).NotEmpty();
            RuleFor(p => p.RepositoryUrl).NotEmpty();
        }
    }
}
