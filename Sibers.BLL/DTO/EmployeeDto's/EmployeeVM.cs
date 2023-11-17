using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.DAL.Models;
using Sibers.DAL.RelationModels;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.EmployeeDto_s
{
    public class EmployeeVM
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public long? UserId { get; set; }
        public ICollection<ProjectData> ManagedProjects { get; set; }
        public ICollection<ProjectData> Projects { get; set; }
        public ICollection<JobData> AuthorizedJobs { get; set; }
        public ICollection<JobData> PerformingJobs { get; set; }
    }
}
