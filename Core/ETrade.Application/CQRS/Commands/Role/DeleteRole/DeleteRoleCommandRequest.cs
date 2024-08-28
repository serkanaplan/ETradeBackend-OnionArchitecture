using MediatR;

namespace ETrade.Application.CQRS.Commands.Role.DeleteRole;

public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
{
    public string Id { get; set; }
}