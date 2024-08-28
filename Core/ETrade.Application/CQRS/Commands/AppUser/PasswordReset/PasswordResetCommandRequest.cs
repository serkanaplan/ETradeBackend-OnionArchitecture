using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.PasswordReset;

public class PasswordResetCommandRequest : IRequest<PasswordResetCommandResponse>
{
    public string Email { get; set; }
}