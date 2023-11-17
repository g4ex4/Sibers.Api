using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.DAL.Enums;
using Sibers.WebAPI.Attributes;
using Sibers.WebAPI.Common.Helpers;
using System.Security.Claims;
using static Sibers.WebAPI.Attributes.AuthAttribute;

namespace Sibers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class JobController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IJobService _service;
        public JobController(IMapper mapper, IJobService service)
            => (_mapper, _service) = (mapper, service);

        [HttpPost("Create")]
        [Auth(RoleTypes.Leader, RoleTypes.ProjectManager)]
        public async Task<IActionResult> Create([FromBody] CreateJobDto data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            data.AuthorizerId = UserId;
            return Ok(await _service.CreateJob(data));
        }

        [HttpGet("GetAll")]
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
        [Auth(RoleTypes.Leader, RoleTypes.ProjectManager)]
        public async Task<IActionResult> EditJobById(JobData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var result = await _service.EditJobById(data);
            return Ok(result);
        }

        [HttpPut("SetStatusToJob")]
        public async Task<IActionResult> SetStatusToJob(long id, JobStatus status)
        {
            return Ok(await _service.SetStatusToJob(id, status));
        }

        [HttpDelete("DeleteJobById")]
        [Auth(RoleTypes.Leader, RoleTypes.ProjectManager)]
        public async Task<IActionResult> DeleteJobById(long id)
        {
            return Ok(await _service.DeleteJobById(id));
        }

        [HttpGet("SearchJobs")]
        public async Task<IActionResult> SearchJobs([FromQuery]SearchJobDto searchParams)
        {
            var result = await _service.SearchJobs(searchParams);
            return Ok(FilterByRole.FilterJobs(result, RoleId, UserId));
        }
    }
}
