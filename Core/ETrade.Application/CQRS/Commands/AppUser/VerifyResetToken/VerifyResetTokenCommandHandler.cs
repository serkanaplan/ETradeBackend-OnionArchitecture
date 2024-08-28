using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.VerifyResetToken;

public class VerifyResetTokenCommandHandler(IAuthService authService) : IRequestHandler<VerifyResetTokenCommandRequest, VerifyResetTokenCommandResponse>
{
    readonly IAuthService _authService = authService;

    public async Task<VerifyResetTokenCommandResponse> Handle(VerifyResetTokenCommandRequest request, CancellationToken cancellationToken)
    {
        bool state = await _authService.VerifyResetTokenAsync(request.ResetToken, request.UserId);
        return new()
        {
            State = state
        };
    }
}
