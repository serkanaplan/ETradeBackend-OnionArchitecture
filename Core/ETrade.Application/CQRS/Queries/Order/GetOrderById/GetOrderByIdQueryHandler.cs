using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Queries.Order.GetOrderById;

public class GetOrderByIdQueryHandler(IOrderService orderService) : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    readonly IOrderService _orderService = orderService;

    public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _orderService.GetOrderByIdAsync(request.Id);
        return new()
        {
            Id = data.Id,
            OrderCode = data.OrderCode,
            Address = data.Address,
            BasketItems = data.BasketItems,
            CreatedDate = data.CreatedDate,
            Description = data.Description,
            Completed = data.Completed
        };
    }
}
