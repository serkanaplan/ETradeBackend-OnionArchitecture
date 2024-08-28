using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.LoginUser;

public class LoginUserCommandHandler(IAuthService authService) : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    readonly IAuthService _authService = authService;

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
        return new LoginUserSuccessCommandResponse()
        {
            Token = token
        };
    }
}