using MediatR;

namespace ETrade.Application.CQRS.Queries.AppUser.GetAllUsers;

public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
{
    public int Page { get; set; }
    public int Size { get; set; }
}