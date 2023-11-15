using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.DAL.Models;
using Sibers.DAL.RelationModels;
using System.ComponentModel.DataAnnotations;

namespace Sibers.BLL.DTO.ProjectDto_s
{
    public class CreateProjectDto : IMapWith<Project>
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string PerformerName { get; set; }
        public int Priority { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? EndDate { get; set; }
        public long? ProjectManagerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, Project>()
                .ForMember(project => project.Name,
                    opt => opt.MapFrom(dto => dto.Name))
                .ForMember(project => project.CustomerName,
                    opt => opt.MapFrom(dto => dto.CustomerName))
                .ForMember(project => project.PerformerName,
                    opt => opt.MapFrom(dto => dto.PerformerName))
                .ForMember(project => project.Priority,
                    opt => opt.MapFrom(dto => dto.Priority))
                .ForMember(project => project.EndDate,
                    opt => opt.MapFrom(dto => dto.EndDate))
                .ForMember(project => project.ProjectManagerId,
                    opt => opt.MapFrom(dto => dto.ProjectManagerId))
                .ReverseMap();
        }
    }
}
