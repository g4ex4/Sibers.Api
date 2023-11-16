using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sibers.WebAPI.Models.DTO_s;
using System.Security.Claims;
using Sibers.BLL.Services.Interfaces;
using AutoMapper;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.WebAPI.Models;
using Sibers.BLL.Common.Exceptions;

namespace Sibers.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Register(RegisterDto register)
        {
            var existingUser = await _userManager.FindByNameAsync(register.UserName);
            if (existingUser != null)
            {
                throw new Exception("User with this username already exists.");
            }
            if (register.Password != register.ConfirmPasseord)
            {
                throw new Exception("Password is miss macthing!");
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
            await _signInManager.SignInAsync(user, isPersistent: false);

            var employee = _mapper.Map<CreateEmployeeDto>(register);
            employee.UserId = user.Id;
            var employeeResponse = await _service.CreateEmployee(employee);
            user.EmployeeId = Convert.ToInt32(employeeResponse.Message);
            return Ok(user.Id);
        }

        [HttpPost("/role/set")]
        public async Task SetRole(long userId, long roleId)
        {

            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role is null)
            {
                throw new NotFoundException(nameof(Role), roleId);
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new NotFoundException(nameof(Models.User), userId);
            }

            var identityResult = await _userManager.AddToRoleAsync(user, role.Name);

            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.ToString());
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
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
            return Ok();
        }
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(User user)
        {
            var claims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(
                roles.Select(role => (
                    new Claim(ClaimTypes.Role, role))));

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
