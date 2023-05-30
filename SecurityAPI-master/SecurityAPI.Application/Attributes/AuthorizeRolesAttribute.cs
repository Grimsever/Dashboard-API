using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SecurityAPI.Domain.Enums;

namespace SecurityAPI.Application.Attributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params Role[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(Role), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}