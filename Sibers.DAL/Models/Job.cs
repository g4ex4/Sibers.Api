using Sibers.DAL.Common;
using Sibers.DAL.Enums;

namespace Sibers.DAL.Models
{
    public class Job : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public JobStatus JobStatus { get; set; }
        public Project Project { get; set; }
        public long ProjectId { get; set; }
        public Employee Authorizer { get; set; }
        public long? AuthorizerId { get; set; }
        public Employee? Performer { get; set; }
        public long? PerformerId { get; set; }

    }
}
