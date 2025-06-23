using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyRepos.Domain.ProjectAggregate;
using MyRepos.Domain.ProjectAggregate.ValueObjects;

namespace MyRepos.Infrastructure.Persistence.Configurations
{
    public class ProjectsConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProjectId.Create(value));
        }
    }
}
