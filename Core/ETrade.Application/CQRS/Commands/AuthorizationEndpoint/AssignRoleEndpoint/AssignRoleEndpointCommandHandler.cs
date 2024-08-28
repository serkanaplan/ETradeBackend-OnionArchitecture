using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.AuthorizationEndpoint.AssignRoleEndpoint;

public class AssignRoleEndpointCommandHandler(IAuthorizationEndpointService authorizationEndpointService) : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
{
    readonly IAuthorizationEndpointService _authorizationEndpointService = authorizationEndpointService;

    public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
    {
        await _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
        return new()
        {

        };
    }
}
