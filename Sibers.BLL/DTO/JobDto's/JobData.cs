using Sibers.DAL.Enums;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class JobData
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public JobStatus JobStatus { get; set; }
        public long ProjectId { get; set; }
        public long AuthorizerId { get; set; }
        public long PerformerId { get; set; }
        public long UserId { get; set; }
    }
}
