using BusinessLayer.Abstact;
using EntitiesLayer;
using EntitiesLayer.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace MovieReviewAPP.Extensions
{
    public static class ExceptionMiddleware
    {
        public static void HandleException(this WebApplication app,ILogService logService)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextfeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextfeature != null)
                    {
                        context.Response.StatusCode = contextfeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        logService.LogError($"Sorun Oluştu: {contextfeature.Error}");
                    }
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextfeature.Error.Message
                    }.ToString());
                    
                });
            });      
        }
    }
}
