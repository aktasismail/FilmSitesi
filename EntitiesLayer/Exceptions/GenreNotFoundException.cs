using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Exceptions
{
    public sealed class GenreNotFoundException : NotFoundException
    {
        public GenreNotFoundException(int id) : base($"{id} Numaralı Tür bulunamadı.")
        {

        }
    }
}
