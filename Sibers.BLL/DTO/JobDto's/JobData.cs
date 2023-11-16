using Sibers.DAL.Enums;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class JobData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public JobStatus JobStatus { get; set; }
        public long ProjectId { get; set; }
        public long AuthorizerId { get; set; }
        public long? PerformerId { get; set; }
    }
}
