using MediatR;

namespace ETrade.Application.CQRS.Queries.Order.GetOrderById;

public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
{
    public string Id { get; set; }
}