using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Genres
    {

        [Key]
        public int GenreId { get; set; }
        public string? MovieGenre { get; set; }
        public ICollection<Movies>? Movies { get; set; }
    }
}
