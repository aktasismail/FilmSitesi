using EntitiesLayer.DTO;

namespace MovieWebUi.Models
{
    public class ErrorViewModel
    {
        public IEnumerable<MovieDTO> movieDTO { get; set; }

        public MovieParam param { get; set; }
    }
}
