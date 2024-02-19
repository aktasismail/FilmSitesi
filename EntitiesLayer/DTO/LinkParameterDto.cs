using EntitiesLayer.RequestFeature;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public record LinkParameterDto
    {
        public MovieParameter MovieParameter { get; init; }
        public HttpContext HttpContext { get; set; }
    }
}
