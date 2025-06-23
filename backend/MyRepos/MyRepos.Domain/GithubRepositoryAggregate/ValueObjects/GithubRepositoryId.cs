using MyRepos.Domain.Common.Models;
using System.Numerics;

namespace MyRepos.Domain.GithubRepositoryAggregate.ValueObjects
{
    public sealed class GithubRepositoryId : ValueObject
    {
        public int Value { get; }

        private GithubRepositoryId(int value)
        {
            Value = value;
        }

        public static GithubRepositoryId Create(int value)
        {
            return new GithubRepositoryId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
