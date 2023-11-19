using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.WebAPI.Common.Helpers;

namespace Sibers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _service;
        public ProjectController(IProjectService service)
            => (_service) = (service);

        [HttpPost("Create")]
        [Authorize(Roles = "Leader")]
        public async Task<Response> Create([FromBody] CreateProjectDto project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            return await _service.CreateProject(project);
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetProjects();
            return Ok(FilterByRole.FilterProjects(result, RoleId, UserId));
        }

        [HttpGet("GetProjectDetailesById")]
        public async Task<IActionResult> GetProjectDetailesById(long projectId)
        {
            await _service.GetProjectDetailesById(projectId);
            return Ok();
        }

        [HttpGet("SearchProject")]
        public async Task<IActionResult> SearchProject([FromQuery] SearchProjectDto project)
        {
            var result = await _service.SearchProjects(project);
            return Ok(FilterByRole.FilterProjects(result, RoleId, UserId));
        }

        [HttpPut("EditProjectById")]
        [Authorize(Roles = "Leader")]
        public async Task<IActionResult> EditProjectById(EditProjectDto project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            return Ok(await _service.EditProjectById(project));
        }

        [HttpDelete("DeleteProjectById")]
        [Authorize(Roles = "Leader")]
        public async Task<Response> DeleteProjectById (long id)
        {
            return await _service.DeleteProjectById(id);
        }

        [HttpDelete("DeleteProjectByName")]
        [Authorize(Roles = "Leader")]
        public async Task<Response> DeleteProjectByName(string name)
        {
            return await _service.DeleteProjectByName(name);
        }

        [HttpDelete("DeleteEmployeeFromProjectById")]
        [Authorize(Roles = "Leader, ProjectManager")]
        public async Task<Response> DeleteEmployeeFromProjectById(long employeeId, long projectId)
        {
            return await _service.DeleteEmployeeFromProjectById(employeeId, projectId);
        }

        [HttpPut("PutEmployeeToProject")]
        [Authorize(Roles = "Leader, ProjectManager")]
        public async Task<IActionResult> PutEmployeeToProject(long employeeId, long projectId)
        {
            return Ok(await _service.PutEmployeeToProject(employeeId, projectId));
        }
    }
}
