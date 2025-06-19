using FluentValidation;

namespace MyRepos.Application.Projects.Commands.AddFavorite
{
    public class AddFavoriteCommandValidator
        : AbstractValidator<AddFavoriteCommand>
    {
        public AddFavoriteCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
