using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Exceptions
{
    public class MovieRateBadRequest:BadRequestException
    {
        public MovieRateBadRequest():base("Lütfen 1 ile 10 arası bir değer seçiniz.")
        {
            
        }
    }
}
