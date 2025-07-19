using FluentValidation;

namespace MyRepos.Application.Readmes.Queries.GetReadmeQuery
{
    public class GetReadmeQueryValidator : AbstractValidator<GetReadmeQuery>
    {
        public GetReadmeQueryValidator()
        {
            RuleFor(r => r.Owner).NotEmpty();
            RuleFor(r => r.RepositoryName).NotEmpty();
        }
    }
}