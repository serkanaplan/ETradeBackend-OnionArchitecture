namespace ETrade.Application.Abstractions.Authentications;

public interface IExternalAuthentication
{
    // Task<DTOs.Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
    Task<DTOs.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
}
