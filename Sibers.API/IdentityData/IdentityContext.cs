using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sibers.WebAPI.Models;
using System.Reflection.Emit;

namespace Sibers.WebAPI.IdentityData
{
    public class IdentityContext : IdentityDbContext<User, Role, long>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Employee" },
                new Role { Id = 2, Name = "ProjectManager" },
                new Role { Id = 3, Name = "Leader" }
            );
            User user = new User()
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
            };
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "admin");
            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long>
                {
                    UserId = 1,
                    RoleId = 3
                });
        }
    }
}
