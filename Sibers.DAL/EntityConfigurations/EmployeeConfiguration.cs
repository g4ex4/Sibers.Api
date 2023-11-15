using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.DAL.Models;
using Sibers.DAL.RelationModels;

namespace Sibers.DAL.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(e => e.Projects)
                .WithMany(p => p.Employees)
                .UsingEntity<ProjectEmployee>(
                    pe => pe.HasOne(p => p.Project)
                            .WithMany(p => p.ProjectEmployees)
                            .HasForeignKey(pe => pe.ProjectId),
                    pe => pe.HasOne(e => e.Employee)
                            .WithMany(e => e.ProjectEmployees)
                            .HasForeignKey(pe => pe.EmployeeId),
                    pe =>
                    {
                        pe.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });
                        pe.ToTable("ProjectEmployee");
                    });
        }
    }
}
