using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.DAL.Models;

namespace Sibers.BLL.Services.Interfaces
{
    public interface IProjectService : IService
    {
        Task<Response> CreateProject(CreateProjectDto project);
        Task<ProjectData[]> GetProjects();
        Task<ProjectData[]> SearchProjects(SearchProjectDto searchParams);
        Task<Project> EditProjectById(EditProjectDto project);
        Task<Response> DeleteProjectById(long projectId);
        Task<Response> DeleteEmployeeFromProjectById(long employeeId, long projectId);
        Task<ProjectData> PutEmployeeToProject(long employeeId, long projectId);
    }
}
