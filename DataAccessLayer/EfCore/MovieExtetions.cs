using EntitiesLayer;
using System.Linq.Dynamic.Core;
using DataAccessLayer.EfCore.Extentions;

namespace DataAccessLayer.EfCore
{
    public static class MovieExtetions
    {
        public static IQueryable<Movies> FilterMovie(this IQueryable<Movies> movies,
            uint minrate,uint maxrate)=>
            movies.Where(m => m.ImdbRate>=minrate && m.ImdbRate<=maxrate);
        public static IQueryable<Movies> Searching(this IQueryable<Movies> movies,string searchparameter)
        {
            if (string.IsNullOrWhiteSpace(searchparameter))
                return movies;
            var lowercase = searchparameter.Trim().ToLower();
            return movies.Where(m => m.Moviename.ToLower().Contains(lowercase));
        }
        public static IQueryable<Movies> Sort(this IQueryable<Movies> movies, string sortparameter)
        {
            if (string.IsNullOrWhiteSpace(sortparameter))
            {
                return movies.OrderBy(x => x.Moviename); //sıralama parametresi boş ise normal sıralama yap
            }
            var query = SortingExtentions.SortingQuery<Movies>(sortparameter);
            if (query is null)
                return movies.OrderBy(z => z.Moviename);
            return movies.OrderBy(query);

        }
    }
}
