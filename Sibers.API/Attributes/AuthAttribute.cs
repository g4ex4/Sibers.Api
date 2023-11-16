using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Sibers.WebAPI.Attributes
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(params RoleTypes[] roles)
        {
            var rolesList = new List<RoleTypes>(roles).Select(x => x.ToString());

            var allowRoles = "";
            foreach (var r in rolesList)
            {
                allowRoles += r;
            }
            Roles = allowRoles;
        }

        public enum RoleTypes
        {
            Employee = 1,
            ProjectManager,
            Leader
        }
    }
}
