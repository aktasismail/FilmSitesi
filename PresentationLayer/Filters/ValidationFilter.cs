using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Filters
{
    public class ValidationFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var x = context.ActionArguments.SingleOrDefault(p => p.Value.ToString().Contains("Dto")).Value;
            if (x is null)
            {
                context.Result = new BadRequestObjectResult($"Controller : {controller} Action {action} bulunamadı");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
        
    }
}
