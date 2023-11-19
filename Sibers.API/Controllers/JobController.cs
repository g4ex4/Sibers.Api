using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.DAL.Enums;
using Sibers.WebAPI.Common.Helpers;

namespace Sibers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class JobController : BaseController
    {
        private readonly IJobService _service;
        public JobController(IJobService service)
            => (_service) = (service);

        [HttpPost("Create")]
        [Authorize(Roles = "Leader, ProjectManager")]
        public async Task<Response> Create(CreateJobDto data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            data.AuthorizerId = UserId;
            return await _service.CreateJob(data);
        }

        [HttpGet("GetAllJobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            var result = await _service.GetAllJobs();
            return Ok(FilterByRole.FilterJobs(result, RoleId, UserId));
        }

        [HttpGet("GetJobDetailesById")]
        public async Task<IActionResult> GetJobDetailesById(long projectId)
        {
            return Ok(await _service.GetJobDetailesById(projectId));
        }

        [HttpPut("EditJobById")]
        [Authorize(Roles = "Leader, ProjectManager")]
        public async Task<IActionResult> EditJobById(JobData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var result = await _service.EditJobById(data);
            return Ok(result);
        }

        [HttpPut("SetStatusToJobById")]
        public async Task<IActionResult> SetStatusToJobById(long id, JobStatus status)
        {
            return Ok(await _service.SetStatusToJobById(id, status));
        }

        [HttpPut("SetStatusToJobByName")]
        public async Task<IActionResult> SetStatusToJobByName(string name, JobStatus status)
        {
            return Ok(await _service.SetStatusToJobByName(name, status));
        }

        [HttpDelete("DeleteJobById")]
        [Authorize(Roles = "Leader, ProjectManager")]
        public async Task<IActionResult> DeleteJobById(long id)
        {
            return Ok(await _service.DeleteJobById(id));
        }

        [HttpDelete("DeleteJobByName")]
        [Authorize(Roles = "Leader, ProjectManager")]
        public async Task<Response> DeleteJobByName(string name)
        {
            return await _service.DeleteJobByName(name);
        }

        [HttpGet("SearchJobs")]
        public async Task<IActionResult> SearchJobs([FromQuery]SearchJobDto searchParams)
        {
            var result = await _service.SearchJobs(searchParams);
            return Ok(FilterByRole.FilterJobs(result, RoleId, UserId));
        }
    }
}
