using Sibers.DAL.Common;
using Sibers.DAL.RelationModels;

namespace Sibers.DAL.Models
{
    public class Employee : BaseEntity<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public long? UserId { get; set; }
        public ICollection<Project> ManagedProjects { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Job> AuthorizedJobs { get; set; }
        public ICollection<Job> PerformingJobs { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }

    }
}
