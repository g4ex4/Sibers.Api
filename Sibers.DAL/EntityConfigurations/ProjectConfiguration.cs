using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.DAL.Models;

namespace Sibers.DAL.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(p => p.Jobs)
                .WithOne(j => j.Project)
                .HasForeignKey(j => j.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.ProjectManager)
                .WithMany(e => e.ManagedProjects)
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
