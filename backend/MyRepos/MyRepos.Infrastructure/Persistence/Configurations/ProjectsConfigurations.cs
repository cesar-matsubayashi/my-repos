using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyRepos.Domain.Project;
using MyRepos.Domain.Project.ValueObjects;

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
