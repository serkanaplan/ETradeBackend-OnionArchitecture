using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.GoogleLogin;

public class GoogleLoginCommandHandler(IAuthService authService) : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
{
    readonly IAuthService _authService = authService;

    public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.GoogleLoginAsync(request.IdToken, 900);
        return new() { Token = token };
    }
}
