using ETrade.Application.DTOs;

namespace ETrade.Application.CQRS.Commands.AppUser.GoogleLogin;

public class GoogleLoginCommandResponse
{
    public Token Token { get; set; }
}
