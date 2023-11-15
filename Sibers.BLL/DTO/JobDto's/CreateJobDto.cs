using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.DAL.Enums;
using Sibers.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class CreateJobDto : IMapWith<Job>
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public JobStatus JobStatus { get; set; }
        public long ProjectId { get; set; }
        public long? PerformerId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateJobDto, Job>().ReverseMap();
        }
    }
}
