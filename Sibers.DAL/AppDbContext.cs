using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sibers.DAL.Enums;
using Sibers.DAL.Models;
using Sibers.DAL.RelationModels;

namespace Sibers.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder builder)
        {
            #region EmployeeSeeding
            builder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    FirstName = "AdminFirstName",
                    MiddleName = "AdminMiddleName",
                    LastName = "AdminLastName",
                    Email = "admin@gmail.com",
                    UserId = 1,
                });

            builder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 2,
                    FirstName = "ProjectManager",
                    MiddleName = "ProjectManager",
                    LastName = "ProjectManager",
                    Email = "ProjectManager@gmail.com",
                    UserId = 2,
                });

            builder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 3,
                    FirstName = "FreeProjectManager",
                    MiddleName = "FreeProjectManager",
                    LastName = "FreeProjectManager",
                    Email = "FreeProjectManager@gmail.com",
                    UserId = 3,
                });

            builder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 4,
                    FirstName = "Employee",
                    MiddleName = "Employee",
                    LastName = "Employee",
                    Email = "Employee@gmail.com",
                    UserId = 4,
                });

            builder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 5,
                    FirstName = "FreeEmployee",
                    MiddleName = "FreeEmployee",
                    LastName = "FreeEmployee",
                    Email = "FreeEmployee@gmail.com",
                    UserId = 5,
                });
            #endregion

            #region ProjectSeeding
            builder.Entity<Project>().HasData(
                new Project()
                {
                    Id = 1,
                    Name = "SibersTestApi",
                    CustomerName = "SibersCompany",
                    PerformerName = "GTEXCorp",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Priority = 1,
                    ProjectManagerId = 2,
                });

            builder.Entity<Project>().HasData(
                new Project()
                {
                    Id = 2,
                    Name = "FreeProject",
                    CustomerName = "WithoutEmployees",
                    PerformerName = "WithoutJobs",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Priority = 1,
                    ProjectManagerId = 2,
                });


            #endregion

            #region JobSeeding
            builder.Entity<Job>().HasData(
                new Job()
                {
                    Id = 1,
                    Name = "Job - Sibers Project",
                    Comment = "Job - Project #1",
                    JobStatus = JobStatus.Done,
                    Priority = 5,
                    PerformerId  = 4,
                    AuthorizerId = 2,
                    ProjectId = 1
                });

            builder.Entity<Job>().HasData(
                new Job()
                {
                    Id = 2,
                    Name = "Job - GTEX Project",
                    Comment = "Job - Project #2",
                    JobStatus = JobStatus.ToDo,
                    Priority = 10,
                    PerformerId = 4,
                    AuthorizerId = 1,
                    ProjectId = 1
                });
            #endregion

            #region ProjectEmployeeSeeding
            builder.Entity<ProjectEmployee>().HasData(
                new ProjectEmployee()
                {
                    EmployeeId = 4,
                    ProjectId = 1,
                });
            #endregion
        }
    }
}
