using FluentValidation;

namespace MyRepos.Application.Projects.Commands.ChangeFavorite
{
    public class ChangeFavoriteCommandValidator
        : AbstractValidator<ChangeFavoriteCommand>
    {
        public ChangeFavoriteCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.IsFavorite).NotEmpty();
        }
    }
}
