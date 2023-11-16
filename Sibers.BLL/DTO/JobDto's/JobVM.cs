using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.DAL.Enums;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class JobVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public JobStatus JobStatus { get; set; }
        public ProjectData Project { get; set; }
        public long ProjectId { get; set; }
        public EmployeeData Authorizer { get; set; }
        public long AuthorizerId { get; set; }
        public EmployeeData? Performer { get; set; }
        public long? PerformerId { get; set; }
    }
}
