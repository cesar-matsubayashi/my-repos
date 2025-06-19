using BuberDinner.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MyRepos.Api.Common.Mapping;

namespace MyRepos.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, MyReposProblemDetailsFactory>();
            services.AddMappings();

            return services;
        }
    }
}
