using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.Services.Interfaces;
using System.Security.Claims;

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
        public async Task<IActionResult> Create([FromBody] CreateJobDto data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            data.AuthorizerId = UserId;
            return Ok(await _service.CreateJob(data));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllJobs()
        {
            return Ok(await _service.GetAllJobs());
        }

        [HttpGet("GetJobDetailesById")]
        public async Task<IActionResult> GetJobDetailesById(long projectId)
        {
            return Ok(await _service.GetJobDetailesById(projectId));
        }

        [HttpPut("EditJobById")]
        public async Task<IActionResult> EditJobById(JobVM data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var result = await _service.EditJobById(data);
            return Ok(result);
        }

        [HttpDelete("DeleteJobById")]
        public async Task<IActionResult> DeleteJobById(long id)
        {
            return Ok(await _service.DeleteJobById(id));
        }

        [HttpGet("SearchJobs")]
        public async Task<IActionResult> SearchJobs([FromQuery]SearchJobDto searchParams)
        {
            return Ok(await _service.SearchJobs(searchParams));
        }
    }
}
