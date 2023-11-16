using Sibers.DAL.Enums;
using Sibers.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class SearchJobDto
    {
        public string? Name { get; set; }
        public string? Comment { get; set; }
        public int? Priority { get; set; }
        public JobStatus? JobStatus { get; set; }
        public long? ProjectId { get; set; }
        public long? AuthorizerId { get; set; }
        public long? PerformerId { get; set; }
    }
}
