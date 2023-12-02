using Microsoft.AspNetCore.Authorization;

namespace Shipfinity.Api.Helpers
{
    public class CustomRolesAttribute : AuthorizeAttribute
    {
        public CustomRolesAttribute(params string[] roles)
        {
            Roles = String.Join(",", roles);
        }
    }
}
