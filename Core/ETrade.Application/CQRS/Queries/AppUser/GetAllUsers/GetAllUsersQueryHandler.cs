using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Queries.AppUser.GetAllUsers;

public class GetAllUsersQueryHandler(IUserService userService) : IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
{
    readonly IUserService _userService = userService;

    public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUsersAsync(request.Page, request.Size);
        return new()
        {
            Users = users,
            TotalUsersCount = _userService.TotalUsersCount
        };
    }
}
