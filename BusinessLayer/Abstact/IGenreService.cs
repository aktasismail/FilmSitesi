using EntitiesLayer;
using EntitiesLayer.DTO;

namespace BusinessLayer.Abstact
{
    public interface IGenreService
    {
        Task<IEnumerable<Genres>> GetAllGenresAsync(bool trackChanges);
        Task<GenreDTO> CreateGenre(GenreCreatedDTO genre);
        Task DeleteGenre(int id, bool trackChanes);
        Task UpdateGenre(int id, GenreDTO genre, bool trackChanges);
    }
}
