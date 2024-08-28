using MediatR;

namespace ETrade.Application.CQRS.Queries.Role.GetRoleById;

public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
{
    public string Id { get; set; }
}