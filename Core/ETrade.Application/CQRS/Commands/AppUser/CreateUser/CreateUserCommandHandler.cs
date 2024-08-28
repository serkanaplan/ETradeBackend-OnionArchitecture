using ETrade.Application.Abstractions.Services;
using ETrade.Application.DTOs.User;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.CreateUser;

public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    readonly IUserService _userService = userService;

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        CreateUserResponse response = await _userService.CreateAsync(new()
        {
            Email = request.Email,
            NameSurname = request.NameSurname,
            Password = request.Password,
            PasswordConfirm = request.PasswordConfirm,
            Username = request.Username,
        });

        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded,
        };

        //throw new UserCreateFailedException();
    }
}
