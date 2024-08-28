using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Role.UpdateRole;

public class UpdateRoleCommandHandler(IRoleService roleService) : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
{
    readonly IRoleService _roleService = roleService;

    public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleService.UpdateRole(request.Id, request.Name);
        return new() { Succeeded = result };
    }
}
