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
    public interface ICommentRepository : IEntityRepositoryBase<Comments>
    {
        Task<IEnumerable<Comments>> GetAllComment(bool trackChanges);
        Comments GetOneCommentById(int id, bool trackChanges);
        void CreateComment(Comments genres);
        void UpdateComment(Comments genres);
        void DeleteComment(Comments genres);
    }
}
