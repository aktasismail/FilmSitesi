using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Exceptions
{
    public sealed class MovieNotFoundException:NotFoundException
    {
        public MovieNotFoundException(int id) : base($"{id} Numaralı film bulunamadı.")
        {
            
        }
    }
}
