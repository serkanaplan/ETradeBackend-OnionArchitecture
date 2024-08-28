using ETrade.Application.Abstractions.Services;
using ETrade.Application.DTOs;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandHandler(IAuthService authService) : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
{
    readonly IAuthService _authService = authService;

    public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
    {
        Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
        return new() { Token = token };
    }
}
