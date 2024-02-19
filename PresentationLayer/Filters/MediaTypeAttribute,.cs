using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Filters
{
    public class MediaTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headerpresent = context.HttpContext.Request.Headers.ContainsKey("Accept");
            if (!headerpresent)
            {
                context.Result = new BadRequestObjectResult($"Accept Bulunamadı");
                return;
            }
            var mediatype = context.HttpContext.Request.Headers["Accept"].FirstOrDefault();
            if (!MediaTypeHeaderValue.TryParse(mediatype, out MediaTypeHeaderValue? outmediaytpe))
            {
                context.Result = new BadRequestObjectResult($"MediaType bulunamadı");
                return;
            }
            context.HttpContext.Items.Add("AcceptHeaderMediaType", outmediaytpe);
        }
    }
}
