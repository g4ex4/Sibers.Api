using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Sibers.WebAPI.Attributes
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public AuthAttribute(params RoleTypes[] roles)
        {
            var rolesList = new List<RoleTypes>(roles).Select(x => x.ToString());

            var aloweRoles = "";
            foreach (var r in rolesList)
            {
                aloweRoles += r;
            }
            Roles = aloweRoles;
        }

        public enum RoleTypes
        {
            Employee = 0,
            ProjectManager = 1,
            Leader = 2
        }
    }
}
