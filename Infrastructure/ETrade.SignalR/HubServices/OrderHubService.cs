using ETrade.Application.Abstractions.Hubs;
using ETrade.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ETrade.SignalR.HubServices;

public class OrderHubService(IHubContext<OrderHub> hubContext) : IOrderHubService
{
    readonly IHubContext<OrderHub> _hubContext = hubContext;

    public async Task OrderAddedMessageAsync(string message)
        => await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.OrderAddedMessage, message);
}
