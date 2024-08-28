using ETrade.Application.Abstractions.Authentications;

namespace ETrade.Application.Abstractions.Services;

public interface IAuthService : IExternalAuthentication, IInternalAuthentication
{
    Task PasswordResetAsnyc(string email);
    Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
}
