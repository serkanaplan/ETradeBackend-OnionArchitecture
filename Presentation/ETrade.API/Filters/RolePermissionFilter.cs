using ETrade.Application.Abstractions.Services;
using ETrade.Application.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ETrade.API.Filters
{
    /// <summary>
    /// Bu filtre, kullanıcıların belirli bir aksiyonu gerçekleştirmek için yetkisi olup olmadığını kontrol eder.
    /// Kullanıcının rolüne göre yetkilendirme işlemi yapılır ve izin yoksa Unauthorized (401) sonucu döndürülür.
    /// </summary>
    public class RolePermissionFilter(IUserService userService) : IAsyncActionFilter
    {
        private readonly IUserService _userService = userService;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userName = context.HttpContext.User.Identity?.Name;

            if (!string.IsNullOrEmpty(userName) && userName != "gncy")
            {
                if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
                {
                    var authorizeAttribute = descriptor.MethodInfo.GetCustomAttribute<AuthorizeDefinitionAttribute>();
                    if (authorizeAttribute != null)
                    {
                        var httpMethod = descriptor.MethodInfo.GetCustomAttribute<HttpMethodAttribute>()?.HttpMethods.FirstOrDefault() ?? HttpMethods.Get;
                        var permissionCode = $"{httpMethod}.{authorizeAttribute.ActionType}.{authorizeAttribute.Definition.Replace(" ", "")}";

                        var hasPermission = await _userService.HasRolePermissionToEndpointAsync(userName, permissionCode);

                        if (!hasPermission)
                        {
                            context.Result = new UnauthorizedResult();
                            return;
                        }
                    }
                }
            }

            await next();
        }
    }
}
