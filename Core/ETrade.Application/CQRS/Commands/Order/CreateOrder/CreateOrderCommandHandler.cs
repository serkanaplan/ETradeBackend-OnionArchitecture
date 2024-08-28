using ETrade.Application.Abstractions.Hubs;
using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Order.CreateOrder;

public class CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService, IOrderHubService orderHubService) : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    readonly IOrderService _orderService = orderService;
    readonly IBasketService _basketService = basketService;
    readonly IOrderHubService _orderHubService = orderHubService;

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        await _orderService.CreateOrderAsync(new()
        {
            Address = request.Address,
            Description = request.Description,
            BasketId = _basketService.GetUserActiveBasket?.Id.ToString()
        });

        await _orderHubService.OrderAddedMessageAsync("Heyy, yeni bir sipariş geldi! :) ");

        return new();
    }
}
