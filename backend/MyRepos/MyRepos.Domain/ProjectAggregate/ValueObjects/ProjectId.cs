using MyRepos.Domain.Common.Models;

namespace MyRepos.Domain.ProjectAggregate.ValueObjects
{
    public sealed class ProjectId : ValueObject
    {
        public Guid Value { get; }

        private ProjectId(Guid value)
        {
            Value = value;
        }
        private ProjectId() { }

        public static ProjectId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ProjectId Create(Guid value)
        {
            return new ProjectId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
