using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.PasswordReset;

public class PasswordResetCommandHandler(IAuthService authService) : IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
{
    readonly IAuthService _authService = authService;

    public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
    {
        await _authService.PasswordResetAsnyc(request.Email);
        return new();
    }
}
