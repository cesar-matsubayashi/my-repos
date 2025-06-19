
using ErrorOr;

namespace MyRepos.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Project
        {
            public static Error NotFound => Error.NotFound(
                code: "Project.NotFound",
                description: "Project not found.");
        }
    }
}
