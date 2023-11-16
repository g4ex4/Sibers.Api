using AutoMapper;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.DAL.Enums;
using Sibers.DAL.Models;
using System.Reflection;

namespace Sibers.BLL.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            ApplyMappingsFromAssembly(assembly);

            CreateMap<Project, ProjectVM>()
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
                .ForMember(data => data.EndDate,
                    opt => opt.MapFrom(project => project.EndDate))
                .ForMember(data => data.ProjectManagerId,
                    opt => opt.MapFrom(project => project.ProjectManagerId))
                .ReverseMap();

            CreateMap<Project, ProjectData>()
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
                .ReverseMap();

            CreateMap<Employee, EmployeeData>()
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

            CreateMap<Employee, CreateEmployeeDto>()
                .ForMember(e => e.UserId,
                opt => opt.MapFrom(e => e.UserId))
                .ForMember(e => e.FirstName,
                opt => opt.MapFrom(e => e.FirstName))
                .ForMember(e => e.LastName,
                opt => opt.MapFrom(e => e.LastName))
                .ForMember(e => e.MiddleName,
                opt => opt.MapFrom(e => e.MiddleName))
                .ForMember(e => e.Email,
                opt => opt.MapFrom(e => e.Email))
                .ReverseMap();

            CreateMap<Employee, EmployeeVM>()
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

            CreateMap<Job, JobVM>()
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

            CreateMap<Job, JobData>()
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
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
