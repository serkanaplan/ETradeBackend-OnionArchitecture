using ETrade.Application.DTOs;

namespace ETrade.Application.CQRS.Commands.AppUser.LoginUser;

public class LoginUserCommandResponse
{

}
public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
{
    public Token Token { get; set; }
}
public class LoginUserErrorCommandResponse : LoginUserCommandResponse
{
    public string Message { get; set; }
}
