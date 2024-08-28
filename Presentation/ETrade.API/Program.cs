using ETrade.Infrastructure.Services.Storage.Local;
using ETrade.Infrastructure;
using ETrade.API.Filters;
using ETrade.Persistence;
using ETrade.Application;
using ETrade.SignalR;
using Serilog;
using ETrade.API.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();//Bu servis, uygulamamızın herhangi bir yerinde mevcut HTTP isteğine ve yanıtına erişmemizi sağlar.
builder.Services.AddControllers(o =>
{
    o.Filters.Add<RolePermissionFilter>();
    o.Filters.Add<ValidationFilter>();
}).AddPersistenceValidators();

builder.Services.AddStorage<LocalStorage>();
// builder.Services.AddStorage(StorageType.Local);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddSignalRServices();


builder.Services.AddServiceExtensions(builder.Configuration);
builder.Host.ConfigureLogging(builder.Configuration);

    
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseUserLogging();
app.MapControllers();
app.MapHubs();

app.Run();
