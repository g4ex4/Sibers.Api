using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.DAL.Models;
using System.Net;

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
        public async Task<IActionResult> Create([FromBody] CreateProjectDto project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            return Ok(await _service.CreateProject(project));
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetProjects();
            return Ok(result);
        }

        [HttpGet("GetProjectDetailesById")]
        public async Task<IActionResult> GetProjectDetailesById(long projectId)
        {
            return Ok(await _service.GetProjectDetailesById(projectId));
        }

        [HttpGet("SearchProject")]
        public async Task<IActionResult> SearchProject([FromQuery] SearchProjectDto project)
        {
            var result = await _service.SearchProjects(project);
            return Ok(result);
        }

        [HttpPut("EditProjectById")]
        public async Task<IActionResult> EditProjectById(EditProjectDto project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));
            return Ok(await _service.EditProjectById(project));
        }

        [HttpDelete("DeleteProjectById")]
        public async Task<IActionResult> DeleteProjectById (long projectId)
        {
            return Ok(await _service.DeleteProjectById(projectId));
        }

        [HttpDelete("DeleteEmployeeFromProjectById")]
        public async Task<IActionResult> DeleteEmployeeFromProjectById(long employeeId, long projectId)
        {
            return Ok(await _service.DeleteEmployeeFromProjectById(employeeId, projectId));
        }

        [HttpPut("PutEmployeeToProject")]
        public async Task<IActionResult> PutEmployeeToProject(long employeeId, long projectId)
        {
            return Ok(await _service.PutEmployeeToProject(employeeId, projectId));
        }

    }
}
