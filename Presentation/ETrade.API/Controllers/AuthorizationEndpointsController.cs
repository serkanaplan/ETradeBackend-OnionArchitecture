using ETrade.Application.CQRS.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using ETrade.Application.CQRS.Queries.AuthorizationEndpoint.GetRolesToEndpoint;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationEndpointsController(IMediator mediator) : ControllerBase
{
    readonly IMediator _mediator = mediator;

    [HttpPost("[action]")]
    public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointQueryRequest rolesToEndpointQueryRequest)
    {
        GetRolesToEndpointQueryResponse response = await _mediator.Send(rolesToEndpointQueryRequest);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
    {
        assignRoleEndpointCommandRequest.Type = typeof(Program);
        AssignRoleEndpointCommandResponse response = await _mediator.Send(assignRoleEndpointCommandRequest);
        return Ok(response);
    }
}
