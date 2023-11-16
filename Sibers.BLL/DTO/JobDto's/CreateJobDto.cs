using Sibers.BLL.Common.Mappings;
using Sibers.DAL.Enums;
using Sibers.DAL.Models;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class CreateJobDto
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public JobStatus JobStatus { get; set; }
        public long ProjectId { get; set; }
        [JsonIgnore]
        public long? AuthorizerId { get; set; }
        public long? PerformerId { get; set; }
    }
}
