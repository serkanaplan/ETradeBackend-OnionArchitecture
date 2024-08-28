using ETrade.Application.DTOs;

namespace ETrade.Application.CQRS.Commands.AppUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandResponse
{
    public Token Token { get; set; }
}
