using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Basket.RemoveBasketItem;

public class RemoveBasketItemCommandHandler(IBasketService basketService) : IRequestHandler<RemoveBasketItemCommandRequest, RemoveBasketItemCommandResponse>
{
    readonly IBasketService _basketService = basketService;

    public async Task<RemoveBasketItemCommandResponse> Handle(RemoveBasketItemCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.RemoveBasketItemAsync(request.BasketItemId);
        return new();
    }
}
