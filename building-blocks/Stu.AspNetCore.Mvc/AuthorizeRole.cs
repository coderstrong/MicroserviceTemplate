using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Stu.AspNetCore.Mvc.Interfaces;

namespace Stu.AspNetCore.Mvc
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    internal class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        public AuthorizeRoleAttribute(params IRoleCode[] roles)
        {
            Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }
}
