using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.AssignRoleToUser;

public class AssignRoleToUserCommandHandler(IUserService userService) : IRequestHandler<AssignRoleToUserCommandRequest, AssignRoleToUserCommandResponse>
{
    readonly IUserService _userService = userService;

    public async Task<AssignRoleToUserCommandResponse> Handle(AssignRoleToUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userService.AssignRoleToUserAsnyc(request.UserId, request.Roles);
        return new();
    }
}
