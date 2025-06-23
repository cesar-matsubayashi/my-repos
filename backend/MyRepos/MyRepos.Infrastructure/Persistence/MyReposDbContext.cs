using Microsoft.EntityFrameworkCore;
using MyRepos.Domain.ProjectAggregate;

namespace MyRepos.Infrastructure.Persistence
{
    public class MyReposDbContext : DbContext
    {
        public MyReposDbContext(DbContextOptions<MyReposDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(MyReposDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
