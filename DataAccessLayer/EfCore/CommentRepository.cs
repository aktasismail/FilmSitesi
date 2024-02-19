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
    public class CommentRepository : EntityRepositoryBase<Comments>, ICommentRepository
    {
        public CommentRepository(MovieDbContext context) :
    base(context)
        {

        }
        public void CreateComment(Comments comments) => Create(comments);

        public void DeleteComment(Comments comments) => Delete(comments);


        public async Task<IEnumerable<Comments>> GetAllComment(bool trackChanges) =>
             await GetAll(trackChanges)
                .ToListAsync();

        public Comments GetOneCommentById(int id, bool trackChanges) =>
             Get(c => c.CommentId.Equals(id), trackChanges)
                .SingleOrDefault();

        public void UpdateComment(Comments comments)
        {
            throw new NotImplementedException();
        }
    }
}
