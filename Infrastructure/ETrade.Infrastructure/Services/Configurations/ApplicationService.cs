using ETrade.Application.Abstractions.Configurations;
using ETrade.Application.CustomAttributes;
using ETrade.Application.DTOs.Configuration;
using ETrade.Application.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;
using Action = ETrade.Application.DTOs.Configuration.Action;

namespace ETrade.Infrastructure.Services.Configurations
{
    public class ApplicationService : IApplicationService
    {
        public List<Menu> GetAuthorizeDefinitionEndpoints(Type type)
        {
            var assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));

            var menus = new List<Menu>();

            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods()
                                        .Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)));

                foreach (var action in actions)
                {
                    var authorizeAttribute = action.GetCustomAttribute<AuthorizeDefinitionAttribute>();
                    if (authorizeAttribute == null) continue;

                    var menu = menus.FirstOrDefault(m => m.Name == authorizeAttribute.Menu)
                               ?? new Menu { Name = authorizeAttribute.Menu, Actions = new List<Action>() };

                    if (!menus.Contains(menu)) menus.Add(menu);

                    var httpMethod = action.GetCustomAttribute<HttpMethodAttribute>()?.HttpMethods.First() ?? HttpMethods.Get;

                    menu.Actions.Add(new Action
                    {
                        ActionType = Enum.GetName(typeof(ActionType), authorizeAttribute.ActionType),
                        Definition = authorizeAttribute.Definition,
                        HttpType = httpMethod,
                        Code = $"{httpMethod}.{authorizeAttribute.ActionType}.{authorizeAttribute.Definition.Replace(" ", "")}"
                    });
                }
            }

            return menus;
        }
    }
}
