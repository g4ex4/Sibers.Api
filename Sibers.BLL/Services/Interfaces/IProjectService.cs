using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.ProjectDto_s;
namespace Sibers.BLL.Services.Interfaces
{
    public interface IProjectService : IService
    {
        Task<Response> CreateProject(CreateProjectDto project);
        Task<List<ProjectVM>> GetProjects();
        Task<ProjectVM> GetProjectDetailesById(long projectId);
        Task<List<ProjectVM>> SearchProjects(SearchProjectDto searchParams);
        Task<ProjectData> EditProjectById(EditProjectDto project);
        Task<Response> DeleteProjectById(long projectId);
        Task<Response> DeleteProjectByName(string name);
        Task<Response> DeleteEmployeeFromProjectById(long employeeId, long projectId);
        Task<ProjectVM> PutEmployeeToProject(long employeeId, long projectId);
    }
}
