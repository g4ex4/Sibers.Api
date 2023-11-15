using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.DAL.RelationModels;

namespace Sibers.DAL.EntityConfigurations
{
    public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            builder.HasOne(p => p.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Employee)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
