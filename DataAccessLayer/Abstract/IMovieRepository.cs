using EntitiesLayer;
using EntitiesLayer.RequestFeature;

namespace DataAccessLayer.Abstract
{
    public interface IMovieRepository : IEntityRepositoryBase<Movies>
    {
        void CreateMovie(Movies movies);
        void DeleteMovie(Movies movies);
        Movies GetaMovie(int id, bool trackChanges);
        Task<IEnumerable<Movies>> GetAllMovie(MovieParameter moviePageParameter, bool trackchanges);
        Task<IEnumerable<Movies>> GetLast(bool trackchanges);
        void UpdateMovie(Movies movies);
    }
}
