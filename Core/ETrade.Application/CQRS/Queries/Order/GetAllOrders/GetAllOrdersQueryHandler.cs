using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Queries.Order.GetAllOrders;

public class GetAllOrdersQueryHandler(IOrderService orderService) : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
{
    readonly IOrderService _orderService = orderService;

    public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _orderService.GetAllOrdersAsync(request.Page, request.Size);

        return new()
        {
            TotalOrderCount = data.TotalOrderCount,
            Orders = data.Orders
        };
    }
}
