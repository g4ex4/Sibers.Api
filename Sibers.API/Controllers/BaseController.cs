using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Sibers.WebAPI.Attributes.AuthAttribute;

namespace Sibers.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        internal long? UserId => !User.Identity.IsAuthenticated
            ? null
            : Int64.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        internal long? RoleId => !User.Identity.IsAuthenticated
            ? null
            : (int)Enum.Parse(typeof(RoleTypes), User.FindFirst(ClaimTypes.Role).Value);
    }
}
