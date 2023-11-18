using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.DAL.Enums;
using Sibers.DAL.Models;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class JobVM : IMapWith<Job>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Job, JobVM>()
                .ForMember(e => e.Id,
                opt => opt.MapFrom(e => e.Id))
                .ForMember(e => e.Name,
                opt => opt.MapFrom(e => e.Name))
                .ForMember(e => e.Comment,
                opt => opt.MapFrom(e => e.Comment))
                .ForMember(e => e.Priority,
                opt => opt.MapFrom(e => e.Priority))
                .ForMember(e => e.JobStatus,
                opt => opt.MapFrom(e => e.JobStatus))
                .ForMember(e => e.ProjectId,
                opt => opt.MapFrom(e => e.ProjectId))
                .ForMember(e => e.AuthorizerId,
                opt => opt.MapFrom(e => e.AuthorizerId))
                .ForMember(e => e.PerformerId,
                opt => opt.MapFrom(e => e.PerformerId))
                .ReverseMap();
        }
    }
}
