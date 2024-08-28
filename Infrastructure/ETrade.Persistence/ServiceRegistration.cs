using ETrade.Application.Repositories.ProductImageFileRepository;
using ETrade.Persistence.Repositories.ProductImageFileRepository;
using ETrade.Persistence.Repositories.CompletedOrderRepository;
using ETrade.Application.Repositories.CompletedOrderRepository;
using ETrade.Persistence.Repositories.InvoiceFileRepository;
using ETrade.Application.Repositories.InvoiceFileRepository;
using ETrade.Persistence.Repositories.BasketItemRepository;
using ETrade.Application.Repositories.BasketItemRepository;
using ETrade.Persistence.Repositories.CustomerRepository;
using ETrade.Application.Repositories.CustomerRepository;
using ETrade.Application.Repositories.EndpointRepository;
using ETrade.Persistence.Repositories.EndpointRepository;
using ETrade.Application.Repositories.ProductRepository;
using ETrade.Persistence.Repositories.ProductRepository;
using ETrade.Application.Repositories.BasketRepository;
using ETrade.Application.Repositories.OrderRepository;
using ETrade.Persistence.Repositories.OrderRepository;
using ETrade.Application.Abstractions.Authentications;
using ETrade.Application.Repositories.FileRepository;
using ETrade.Persistence.Repositories.FileRepository;
using ETrade.Application.Repositories.MenuRepository;
using ETrade.Persistence.Repositories.MenuRepository;
using Microsoft.Extensions.DependencyInjection;
using ETrade.Persistence.Validators.Products;
using Microsoft.Extensions.Configuration;
using ETrade.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using ETrade.Persistence.Contexts;
using ETrade.Persistence.Services;
using FluentValidation;
using ETrade.Persistence.Repositories.BasketRepositoryRepository;
using ETrade.Application.Abstractions.Services;

namespace ETrade.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ETradeAPIDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
        services.AddIdentity<AppUser, AppRole>(options =>
           {
               options.Password.RequiredLength = 3;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireDigit = false;
               options.Password.RequireLowercase = false;
               options.Password.RequireUppercase = false;
           }).AddEntityFrameworkStores<ETradeAPIDBContext>().AddDefaultTokenProviders();


        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();
        services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
        services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
        services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
        services.AddScoped<ICompletedOrderReadRepository, CompletedOrderReadRepository>();
        services.AddScoped<ICompletedOrderWriteRepository, CompletedOrderWriteRepository>();
        services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
        services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();
        services.AddScoped<IMenuReadRepository, MenuReadRepository>();
        services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExternalAuthentication, AuthService>();
        services.AddScoped<IInternalAuthentication, AuthService>();
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

    }

    public static void AddPersistenceValidators(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
    }
}