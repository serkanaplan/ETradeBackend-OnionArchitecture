using MediatR;

namespace ETrade.Application.CQRS.Queries.AppUser.GetRolesToUser;

public class GetRolesToUserQueryRequest : IRequest<GetRolesToUserQueryResponse>
{
    public string UserId { get; set; }
}