using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.RequestFeature;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EfCore
{
    public class MovieRepository : EntityRepositoryBase<Movies>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context) : base(context)
        {   
        }
        public void CreateMovie(Movies movies) =>
            Create(movies);
        public void DeleteMovie(Movies movies) =>
            Delete(movies);
        public async Task<IEnumerable<Movies>> GetAllMovie(MovieParameter moviePageParameter, bool trackchanges)
        {
            var movies = await GetAll(trackchanges)
            .FilterMovie(moviePageParameter.MinRate, moviePageParameter.MaxRate)
            .Searching(moviePageParameter.SearchParameter)
            .Sort(moviePageParameter.OrderBy)
            .ToListAsync();
            return (movies);
        }
        public Movies GetaMovie(int id, bool trackChanges) =>
             Get(x => x.Id.Equals(id), trackChanges).SingleOrDefault();
        public void UpdateMovie(Movies movies)=>
            Update(movies);

        public async Task<IEnumerable<Movies>> GetLast(bool trackchanges)
        {

            var movies = await GetAll(trackchanges).ToListAsync();
            return (movies);
        }
    }
}
