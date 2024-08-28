using ETrade.Application.Abstractions.Configurations;
using ETrade.Application.Abstractions.Services;
using ETrade.Application.Repositories.EndpointRepository;
using ETrade.Application.Repositories.MenuRepository;
using ETrade.Domain.Entities;
using ETrade.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Persistence.Services;

public class AuthorizationEndpointService(IApplicationService applicationService,
    IEndpointReadRepository endpointReadRepository,
    IEndpointWriteRepository endpointWriteRepository,
    IMenuReadRepository menuReadRepository,
    IMenuWriteRepository menuWriteRepository,
    RoleManager<AppRole> roleManager) : IAuthorizationEndpointService
{
    readonly IApplicationService _applicationService = applicationService;
    readonly IEndpointReadRepository _endpointReadRepository = endpointReadRepository;
    readonly IEndpointWriteRepository _endpointWriteRepository = endpointWriteRepository;
    readonly IMenuReadRepository _menuReadRepository = menuReadRepository;
    readonly IMenuWriteRepository _menuWriteRepository = menuWriteRepository;
    readonly RoleManager<AppRole> _roleManager = roleManager;

    public async Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
    {
        Menu _menu = await _menuReadRepository.GetSingleAsync(m => m.Name == menu);
        if (_menu == null)
        {
            _menu = new()
            {
                Id = Guid.NewGuid(),
                Name = menu
            };
            await _menuWriteRepository.AddAsync(_menu);

            await _menuWriteRepository.SaveAsync();
        }

        Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.Menu).Include(e => e.Roles).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);

        if (endpoint == null)
        {
            var action = _applicationService.GetAuthorizeDefinitionEndpoints(type)
                    .FirstOrDefault(m => m.Name == menu)
                    ?.Actions.FirstOrDefault(e => e.Code == code);

            endpoint = new()
            {
                Code = action.Code,
                ActionType = action.ActionType,
                HttpType = action.HttpType,
                Definition = action.Definition,
                Id = Guid.NewGuid(),
                Menu = _menu
            };

            await _endpointWriteRepository.AddAsync(endpoint);
            await _endpointWriteRepository.SaveAsync();
        }

        foreach (var role in endpoint.Roles)
            endpoint.Roles.Remove(role);

        var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

        foreach (var role in appRoles)
            endpoint.Roles.Add(role);
        await _endpointWriteRepository.SaveAsync();
    }

    public async Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
    {
        Endpoint? endpoint = await _endpointReadRepository.Table
            .Include(e => e.Roles)
            .Include(e => e.Menu)
            .FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
        if (endpoint != null)
            return endpoint.Roles.Select(r => r.Name).ToList();
        return null;
    }
}
