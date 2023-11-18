using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.DAL.Models;
using Sibers.DAL.RelationModels;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.EmployeeDto_s
{
    public class EmployeeVM : IMapWith<Employee>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public long? UserId { get; set; }
        public ICollection<ProjectData> ManagedProjects { get; set; }
        public ICollection<ProjectData> Projects { get; set; }
        public ICollection<JobData> AuthorizedJobs { get; set; }
        public ICollection<JobData> PerformingJobs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeVM>()
                .ForMember(e => e.Id,
                opt => opt.MapFrom(e => e.Id))
                .ForMember(e => e.FirstName,
                opt => opt.MapFrom(e => e.FirstName))
                .ForMember(e => e.LastName,
                opt => opt.MapFrom(e => e.LastName))
                .ForMember(e => e.MiddleName,
                opt => opt.MapFrom(e => e.MiddleName))
                .ForMember(e => e.Email,
                opt => opt.MapFrom(e => e.Email))
                .ForMember(e => e.UserId,
                opt => opt.MapFrom(e => e.UserId))
                .ReverseMap();
        }
    }
}
