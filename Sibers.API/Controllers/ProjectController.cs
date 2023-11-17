using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.WebAPI.Attributes;
using Sibers.WebAPI.Common.Helpers;
using System.Security.Claims;
using static Sibers.WebAPI.Attributes.AuthAttribute;

namespace Sibers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProjectService _service;
        public ProjectController(IMapper mapper, IProjectService service)
            => (_mapper, _service) = (mapper, service);

        [HttpPost("Create")]
        [Auth(RoleTypes.Leader)]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            return Ok(await _service.CreateProject(project));
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
        [Auth(RoleTypes.Leader)]
        public async Task<IActionResult> EditProjectById(EditProjectDto project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            return Ok(await _service.EditProjectById(project));
        }

        [HttpDelete("DeleteProjectById")]
        [Auth(RoleTypes.Leader)]
        public async Task<IActionResult> DeleteProjectById (long projectId)
        {
            return Ok(await _service.DeleteProjectById(projectId));
        }

        [HttpDelete("DeleteEmployeeFromProjectById")]
        [Auth(RoleTypes.Leader, RoleTypes.ProjectManager)]
        public async Task<IActionResult> DeleteEmployeeFromProjectById(long employeeId, long projectId)
        {
            return Ok(await _service.DeleteEmployeeFromProjectById(employeeId, projectId));
        }

        [HttpPut("PutEmployeeToProject")]
        [Auth(RoleTypes.Leader, RoleTypes.ProjectManager)]
        public async Task<IActionResult> PutEmployeeToProject(long employeeId, long projectId)
        {
            return Ok(await _service.PutEmployeeToProject(employeeId, projectId));
        }
    }
}
