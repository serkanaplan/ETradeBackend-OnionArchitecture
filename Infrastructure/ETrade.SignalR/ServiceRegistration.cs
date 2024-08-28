using ETrade.Application.Abstractions.Hubs;
using ETrade.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;

namespace ETrade.SignalR;

public static class ServiceRegistration
{
    public static void AddSignalRServices(this IServiceCollection collection)
    {
        collection.AddTransient<IProductHubService, ProductHubService>();
        collection.AddTransient<IOrderHubService, OrderHubService>();
        collection.AddSignalR();
    }
}
