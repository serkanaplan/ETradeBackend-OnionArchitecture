using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ETrade.API.Filters
{
    // Verinin eksik veya hatalı girilmesi durumunda Fluent Validation ile default gelen responsu devre dışı bırakarak,
    // kendi özel responsumuzu oluşturmak için bu filter'ı kullanıyoruz.
    // Bu filter'ı kullanarak, uygulamamızdaki tüm istekler için tutarlı ve merkezi bir doğrulama mekanizması oluşturmuş oluruz.
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage))
                    .ToArray();

                context.Result = new BadRequestObjectResult(errors);
                return;
            }

            await next();
        }
    }

    // Bu filter, hata olması durumunda şu şekilde bir çıktı verecek:
    // [
    //   {
    //     "key": "Price",
    //     "value": [
    //       "'Price' boş olmamalı."
    //     ]
    //   },
    //   {
    //     "key": "Stock",
    //     "value": [
    //       "'Stock' boş olmamalı."
    //     ]
    //   }
    // ]
}
