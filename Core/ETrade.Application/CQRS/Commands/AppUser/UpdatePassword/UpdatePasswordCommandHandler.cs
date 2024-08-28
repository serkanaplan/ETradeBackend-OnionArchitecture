using ETrade.Application.Abstractions.Services;
using ETrade.Application.Exceptions;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AppUser.UpdatePassword;

public class UpdatePasswordCommandHandler(IUserService userService) : IRequestHandler<UpdatePasswordCommandRequest, UpdatePasswordCommandResponse>
{
    readonly IUserService _userService = userService;

    public async Task<UpdatePasswordCommandResponse> Handle(UpdatePasswordCommandRequest request, CancellationToken cancellationToken)
    {
        if (!request.Password.Equals(request.PasswordConfirm)) throw new PasswordChangeFailedException("Lütfen şifreyi birebir doğrulayınız.");

        await _userService.UpdatePasswordAsync(request.UserId, request.ResetToken, request.Password);
        return new();
    }
}
