using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.Services.Interfaces;

namespace Sibers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _service;
        public EmployeeController(IMapper mapper, IEmployeeService service)
            => (_mapper, _service) = (mapper, service);

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            var result = await _service.CreateEmployee(employee);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _service.GetAllEmployees());
        }

        [HttpPut("EditEmployeeById")]
        public async Task<IActionResult> EditEmployeeById(EmployeeData data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var result = await _service.EditEmployeeById(data);
            return Ok(result);
        }

        [HttpDelete("DeleteEmployeeById")]
        public async Task<IActionResult> DeleteEmployeeById(long id)
        {
            return Ok(await _service.DeleteEmployeeById(id));
        }
    }
}
