using BusinessLayer.Abstact;
using EntitiesLayer.Logdetail;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Filters
{
    public class LogFilter:ActionFilterAttribute
    {
        private readonly ILogService _logService;
        public LogFilter(ILogService logService)
        {
            _logService = logService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        private string Log(string message, RouteData routeData)
        {
            var logDetails = new LogDetails()
            {
                ModelModel = message,
                Controller = routeData.Values["controller"],
                Action = routeData.Values["action"]
            };

            if (routeData.Values.Count >= 3)
                logDetails.Id = routeData.Values["Id"];

            return logDetails.ToString();
        }
    }
}
