using ETrade.Application.Abstractions.Services;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Basket.AddItemToBasket;

public class AddItemToBasketCommandHandler(IBasketService basketService) : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
{
    readonly IBasketService _basketService = basketService;

    public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
    {
        await _basketService.AddItemToBasketAsync(new()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity
        });

        return new();
    }
}
