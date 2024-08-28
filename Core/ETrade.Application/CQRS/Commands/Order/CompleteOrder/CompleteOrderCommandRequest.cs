using MediatR;

namespace ETrade.Application.CQRS.Commands.Order.CompleteOrder;

public class CompleteOrderCommandRequest : IRequest<CompleteOrderCommandResponse>
{
    public string Id { get; set; }
}