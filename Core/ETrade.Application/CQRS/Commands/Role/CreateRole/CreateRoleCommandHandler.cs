using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Role.CreateRole;

public class CreateRoleCommandHandler(IRoleService roleService) : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
{
    readonly IRoleService _roleService = roleService;

    public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleService.CreateRole(request.Name);
        return new() { Succeeded = result };
    }
}
