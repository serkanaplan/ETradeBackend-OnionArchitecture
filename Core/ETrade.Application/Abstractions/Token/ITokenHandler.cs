using ETrade.Domain.Entities.Identity;

namespace ETrade.Application.Abstractions.Token;

public interface ITokenHandler
{
    DTOs.Token CreateAccessToken(int second, AppUser appUser);
    string CreateRefreshToken();
}
