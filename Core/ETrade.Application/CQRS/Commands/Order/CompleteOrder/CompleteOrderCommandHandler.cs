using ETrade.Application.Abstractions.Services;
using ETrade.Application.DTOs.Order;
using MediatR;

namespace ETrade.Application.CQRS.Commands.Order.CompleteOrder;

public class CompleteOrderCommandHandler(IOrderService orderService, IMailService mailService) : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
{
    readonly IOrderService _orderService = orderService;
    readonly IMailService _mailService = mailService;

    public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        (bool succeeded, CompletedOrderDTO dto) = await _orderService.CompleteOrderAsync(request.Id);

        if (succeeded) await _mailService.SendCompletedOrderMailAsync(dto.EMail, dto.OrderCode, dto.OrderDate, dto.Username);
        return new();
    }
}
