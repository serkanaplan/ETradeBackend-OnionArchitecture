using ETrade.Application.Abstractions.Hubs;
using ETrade.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ETrade.SignalR.HubServices;

public class ProductHubService(IHubContext<ProductHub> hubContext) : IProductHubService
{
    readonly IHubContext<ProductHub> _hubContext = hubContext;

    public async Task ProductAddedMessageAsync(string message)
    {
        await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage, message);
    }
}
