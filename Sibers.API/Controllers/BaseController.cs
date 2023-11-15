using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sibers.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        internal long? UserId => !User.Identity.IsAuthenticated
            ? null
            : Int64.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
