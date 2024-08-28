using MediatR;

namespace ETrade.Application.CQRS.Commands.Basket.RemoveBasketItem;

public class RemoveBasketItemCommandRequest : IRequest<RemoveBasketItemCommandResponse>
{
    public string BasketItemId { get; set; }
}