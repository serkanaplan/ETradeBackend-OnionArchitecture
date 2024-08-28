using ETrade.Infrastructure.Services.Storage.Azure;
using ETrade.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;
using ETrade.Application.Abstractions.Storage;
using ETrade.Infrastructure.Services.Storage;
using ETrade.Infrastructure.Enums;
using ETrade.Application.Abstractions.Token;
using ETrade.Infrastructure.Services.Token;
using ETrade.Infrastructure.Services;
using ETrade.Application.Abstractions.Configurations;
using ETrade.Infrastructure.Services.Configurations;
using ETrade.Application.Abstractions.Services;

namespace ETrade.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IStorageService, StorageService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        serviceCollection.AddScoped<IMailService, MailService>();
        serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        serviceCollection.AddScoped<IQRCodeService, QRCodeService>();
    }

    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
    // veya
    public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
    {
        switch (storageType)
        {
            case StorageType.Local: serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
            case StorageType.Azure: serviceCollection.AddScoped<IStorage, AzureStorage>();
                break;
            case StorageType.AWS:
                break;
            default: serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
        }
    }
}
