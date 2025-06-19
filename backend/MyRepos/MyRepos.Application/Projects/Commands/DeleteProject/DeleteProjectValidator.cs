using FluentValidation;

namespace MyRepos.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectValidator
        : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
