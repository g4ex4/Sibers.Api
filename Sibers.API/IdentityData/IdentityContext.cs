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
            Database.EnsureDeleted();
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
                new Role { Id = 1, Name = "Employee", NormalizedName = "EMPLOYEE" },
                new Role { Id = 2, Name = "ProjectManager", NormalizedName = "PROJECTMANAGER" },
                new Role { Id = 3, Name = "Leader", NormalizedName = "LEADER" }
            );
            var passwordHasher = new PasswordHasher<User>();

            #region AdminSeeding
            User admin = new User()
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                EmployeeId = 1,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");
            modelBuilder.Entity<User>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long>
                {
                    UserId = 1,
                    RoleId = 3
                });
            #endregion

            #region ProjectManagerSeeding
            User projectManager = new User()
            {
                Id = 2,
                UserName = "ProjectManager",
                NormalizedUserName = "PROJECTMANAGER",
                Email = "ProjectManager@gmail.com",
                EmployeeId = 2,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            projectManager.PasswordHash = passwordHasher.HashPassword(projectManager, "ProjectManager");
            modelBuilder.Entity<User>().HasData(projectManager);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long>
                {
                    UserId = 2,
                    RoleId = 2
                });

            User freeProjectManager = new User()
            {
                Id = 3,
                UserName = "FreeProjectManager",
                NormalizedUserName = "FREEPROJECTMANAGER",
                Email = "FreeProjectManager@gmail.com",
                EmployeeId = 3,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            freeProjectManager.PasswordHash = passwordHasher.HashPassword(freeProjectManager, "FreeProjectManager");
            modelBuilder.Entity<User>().HasData(freeProjectManager);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long>
                {
                    UserId = 3,
                    RoleId = 2
                });
            #endregion

            #region EmployeeSeeding
            User employee = new User()
            {
                Id = 4,
                UserName = "Employee",
                NormalizedUserName = "EMPLOYEE",
                Email = "Employee@gmail.com",
                EmployeeId = 4,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            employee.PasswordHash = passwordHasher.HashPassword(employee, "Employee");
            modelBuilder.Entity<User>().HasData(employee);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long>
                {
                    UserId = 4,
                    RoleId = 1
                });

            User freeEmployee = new User()
            {
                Id = 5,
                UserName = "FreeEmployee",
                NormalizedUserName = "FREEEMPLOYEE",
                Email = "FreeEmployee@gmail.com",
                EmployeeId = 5,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            freeEmployee.PasswordHash = passwordHasher.HashPassword(freeEmployee, "FreeEmployee");
            modelBuilder.Entity<User>().HasData(freeEmployee);

            modelBuilder.Entity<IdentityUserRole<long>>().HasData(
                new IdentityUserRole<long>
                {
                    UserId = 5,
                    RoleId = 1
                });
            #endregion
        }
    }
}
