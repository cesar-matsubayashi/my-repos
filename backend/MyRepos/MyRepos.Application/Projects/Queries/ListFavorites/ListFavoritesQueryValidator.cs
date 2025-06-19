using FluentValidation;

namespace MyRepos.Application.Projects.Queries.ListFavorites
{
    public class ListFavoritesQueryValidator
        : AbstractValidator<ListFavoritesQuery>
    {
        public ListFavoritesQueryValidator() { }
    }
}
