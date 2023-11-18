using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.DAL.Enums;
using Sibers.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.JobDto_s
{
    public class CreateJobDto : IMapWith<Job>
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        [EnumDataType(typeof(JobStatus), ErrorMessage = $"{nameof(JobStatus)} value is not existing")]
        public JobStatus JobStatus { get; set; }
        public long ProjectId { get; set; }
        [JsonIgnore]
        public long? AuthorizerId { get; set; }
        public long? PerformerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Job, CreateJobDto>()
                .ForMember(e => e.Name,
                opt => opt.MapFrom(d => d.Name))
                .ForMember(e => e.Priority,
                opt => opt.MapFrom(d => d.Priority))
                .ForMember(e => e.JobStatus,
                opt => opt.MapFrom(d => d.JobStatus))
                .ForMember(e => e.ProjectId,
                opt => opt.MapFrom(d => d.ProjectId))
                .ForMember(e => e.AuthorizerId,
                opt => opt.MapFrom(d => d.AuthorizerId))
                .ForMember(e => e.Comment,
                opt => opt.MapFrom(d => d.Comment))
                .ReverseMap();
        }
    }
}
