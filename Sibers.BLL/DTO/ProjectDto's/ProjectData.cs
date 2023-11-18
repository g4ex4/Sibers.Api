using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.DAL.Models;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.ProjectDto_s
{
    public class ProjectData : IMapWith<Project>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectData>()
                .ForMember(data => data.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(data => data.Name,
                    opt => opt.MapFrom(project => project.Name))
                .ForMember(data => data.CustomerName,
                    opt => opt.MapFrom(project => project.CustomerName))
                .ForMember(data => data.PerformerName,
                    opt => opt.MapFrom(project => project.PerformerName))
                .ForMember(data => data.Priority,
                    opt => opt.MapFrom(project => project.Priority))
                .ForMember(data => data.StartDate,
                    opt => opt.MapFrom(project => project.StartDate))
                .ForMember(data => data.EndDate,
                    opt => opt.MapFrom(project => project.EndDate))
                .ForMember(data => data.ProjectManagerId,
                    opt => opt.MapFrom(project => project.ProjectManagerId))
                .ForMember(data => data.ProjectManager,
                    opt => opt.MapFrom(project => project.ProjectManager))
                .ReverseMap();
        }
    }
}
