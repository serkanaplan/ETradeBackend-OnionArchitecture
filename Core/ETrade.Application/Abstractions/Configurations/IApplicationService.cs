using ETrade.Application.DTOs.Configuration;

namespace ETrade.Application.Abstractions.Configurations;

public interface IApplicationService
{
    List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
}
