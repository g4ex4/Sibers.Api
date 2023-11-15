using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sibers.DAL.Models;

namespace Sibers.DAL.EntityConfigurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasOne(j => j.Performer)
                .WithMany(e => e.PerformingJobs)
                .HasForeignKey(j => j.PerformerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(j => j.Authorizer)
                .WithMany(e => e.AuthorizedJobs)
                .HasForeignKey(j => j.AuthorizerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
