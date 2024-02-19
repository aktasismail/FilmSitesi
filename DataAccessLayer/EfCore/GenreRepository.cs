using DataAccessLayer.Abstract;
using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCore
{
    public class GenreRepository : EntityRepositoryBase<Genres>, IGenreRepository
    {
        public GenreRepository(MovieDbContext context) :
    base(context)
        {

        }

        public void CreateGenre(Genres genre) => Create(genre);

        public void DeleteGenre(Genres genre) => Delete(genre);

        public async Task<IEnumerable<Genres>> GetAllGenres(bool trackChanges) =>
             await GetAll(trackChanges)
                .OrderBy(c => c.MovieGenre)
                .ToListAsync();

        public Genres GetOneGenreById(int id, bool trackChanges) =>
             Get(c => c.GenreId.Equals(id), trackChanges)
                .SingleOrDefault();

        public void UpdateGenre(Genres genre) => Update(genre);
    }
}
