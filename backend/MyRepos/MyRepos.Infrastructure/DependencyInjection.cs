using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRepos.Application.Common.Persistence;
using MyRepos.Application.Common.Services;
using MyRepos.Infrastructure.Persistence;
using MyRepos.Infrastructure.Persistence.Repositories;
using MyRepos.Infrastructure.Services.Github;
using System;

namespace MyRepos.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddHttpClient<IGithubServive, GithubService>(client =>
            {
                client.DefaultRequestHeaders.Add("User-Agent", "MyRepos/1.0");
                client.Timeout = TimeSpan.FromSeconds(30);
            });

            services.AddDbContext<MyReposDbContext>(options =>
                options.UseInMemoryDatabase("MyReposDb"));

            services.AddScoped<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
