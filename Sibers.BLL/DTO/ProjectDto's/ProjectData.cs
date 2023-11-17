using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.DTO.JobDto_s;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.ProjectDto_s
{
    public class ProjectData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string PerformerName { get; set; }
        public int Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? ProjectManagerId { get; set; }
        [JsonIgnore]
        public EmployeeData ProjectManager { get; set; }
    }
}
