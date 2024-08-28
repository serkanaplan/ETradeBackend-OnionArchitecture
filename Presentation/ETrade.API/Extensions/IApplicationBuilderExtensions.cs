using Microsoft.AspNetCore.Diagnostics;
using Serilog.Context;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ETrade.API.Extensions;

public static class AppExtensions
{
    public static void ConfigureExceptionHandler<T>(this IApplicationBuilder app, ILogger<T> logger)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (exceptionHandlerFeature != null)
                {
                    var errorMessage = exceptionHandlerFeature.Error.Message;
                    logger.LogError(errorMessage);

                    var errorResponse = new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = errorMessage,
                        Title = "Hata alındı!"
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                }
            });
        });


    }

    public static void UseUserLogging(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
         {
             var username = context.User?.Identity?.IsAuthenticated == true ? context.User.Identity.Name : null;
             LogContext.PushProperty("user_name", username);
             await next();
         });
    }
}
