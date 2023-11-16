using Microsoft.AspNetCore.Identity;

namespace Sibers.WebAPI.Models
{
    public class User : IdentityUser<long>
    {
        public long EmployeeId { get; set; }
    }
}
