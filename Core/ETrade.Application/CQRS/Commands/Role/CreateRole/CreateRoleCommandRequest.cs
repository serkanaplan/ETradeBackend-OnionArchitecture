using MediatR;

namespace ETrade.Application.CQRS.Commands.Role.CreateRole;

public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
{
    public string Name { get; set; }
}