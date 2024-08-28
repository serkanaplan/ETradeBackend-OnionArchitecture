using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Queries.AppUser.GetRolesToUser;

public class GetRolesToUserQueryHandler(IUserService userService) : IRequestHandler<GetRolesToUserQueryRequest, GetRolesToUserQueryResponse>
{
    readonly IUserService _userService = userService;

    public async Task<GetRolesToUserQueryResponse> Handle(GetRolesToUserQueryRequest request, CancellationToken cancellationToken)
    {
        var userRoles = await _userService.GetRolesToUserAsync(request.UserId);
        return new()
        {
            UserRoles = userRoles
        };
    }
}
