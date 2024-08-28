using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Basket.UpdateQuantity;

public class UpdateQuantityCommandHandler(IBasketService basketService) : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
{
    readonly IBasketService _basketService = basketService;

    public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.UpdateQuantityAsync(new()
        {
            BasketItemId = request.BasketItemId,
            Quantity = request.Quantity
        });

        return new();
    }
}
