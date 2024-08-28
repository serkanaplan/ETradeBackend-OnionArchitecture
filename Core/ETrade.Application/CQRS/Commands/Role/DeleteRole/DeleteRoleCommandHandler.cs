using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Role.DeleteRole;

public class DeleteRoleCommandHandler(IRoleService roleService) : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
{
    readonly IRoleService _roleService = roleService;

    public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleService.DeleteRole(request.Id);
        return new()
        {
            Succeeded = result,
        };
    }
}
