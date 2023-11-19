using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sibers.WebAPI.Models.DTO_s;
using Sibers.BLL.Services.Interfaces;
using AutoMapper;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.WebAPI.Models;
using Sibers.BLL.Common.Exceptions;
using static Sibers.WebAPI.Attributes.AuthAttribute;
using Sibers.BLL.Common.Responses;

namespace Sibers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IEmployeeService service,
            IMapper mapper,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var existingUser = await _userManager.FindByNameAsync(register.UserName);
            if (existingUser != null)
            {
                throw new Exception("User with this username already exists.");
            }

            var user = new User()
            {
                UserName = register.UserName,
                Email = register.Email,
            };

            var identityResult = await _userManager.CreateAsync(user);
            identityResult = await _userManager.AddPasswordAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                throw new Exception("MinLength=6!");
            }

            var employee = _mapper.Map<CreateEmployeeDto>(register);
            employee.UserId = user.Id;
            var employeeResponse = await _service.CreateEmployee(employee);
            user.EmployeeId = Convert.ToInt32(employeeResponse.Message);
            await _userManager.AddToRoleAsync(user, "Employee");
            await _signInManager.SignInAsync(user, isPersistent: true);
            return Ok(new Response(200, "Registered successfully", true));
        }

        [HttpPost("/role/setRoleToUser")]
        [Authorize(Roles = "Leader")]
        public async Task SetRole(long userId, RoleTypes roleId)
        {

            var role = await _roleManager.FindByIdAsync(((int)roleId).ToString());
            if (role is null)
            {
                throw new NotFoundException(nameof(Role), roleId);
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new NotFoundException(nameof(Models.User), userId);
            }

            var existingRoles = await _userManager.GetRolesAsync(user);
            if (existingRoles.Any())
                await _userManager.RemoveFromRolesAsync(user, existingRoles);

            var identityResult = await _userManager.AddToRoleAsync(user, role.Name);

            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.ToString());
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<Response> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                throw new Exception("User is not found ");
            }

            var passwordCorrect = await _userManager.CheckPasswordAsync(user, login.Password);

            if (!passwordCorrect)
            {
                throw new Exception("Password is not correct");
            }

            await _signInManager.SignInAsync(user, login.RememberMe);
            return new Response(200, "Logined successfully", true);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("GetCurrentRole")]
        public async Task<IActionResult> GetCurrentRole()
        {
            var result = Enum.GetName(typeof(RoleTypes), RoleId.Value);
            return Ok(result);
        }
    }
}
