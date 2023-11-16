using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.DTO.JobDto_s;

namespace Sibers.BLL.DTO.ProjectDto_s
{
    public class ProjectVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string PerformerName { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public EmployeeData? ProjectManager { get; set; }
        public long? ProjectManagerId { get; set; }
        public ICollection<JobData>? Jobs { get; set; }
        public ICollection<EmployeeData>? Employees { get; set; }

    }
}
