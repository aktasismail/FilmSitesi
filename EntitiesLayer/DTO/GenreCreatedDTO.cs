using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTO
{
    public record GenreCreatedDTO
    {
        public string? MovieGenre { get; init; }
    }
}
