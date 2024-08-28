using MediatR;

namespace ETrade.Application.CQRS.Commands.Basket.AddItemToBasket;

public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
}