using MediatR;

namespace ETrade.Application.CQRS.Queries.Order.GetAllOrders;

public class GetAllOrdersQueryRequest : IRequest<GetAllOrdersQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}