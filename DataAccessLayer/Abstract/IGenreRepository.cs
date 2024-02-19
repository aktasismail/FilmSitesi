using EntitiesLayer;
using EntitiesLayer.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenreRepository : IEntityRepositoryBase<Genres>
    {
        Task<IEnumerable<Genres>> GetAllGenres(bool trackChanges);
        Genres GetOneGenreById(int id, bool trackChanges);
        void CreateGenre(Genres genres);
        void UpdateGenre(Genres genres);
        void DeleteGenre(Genres genres);
    }
}
