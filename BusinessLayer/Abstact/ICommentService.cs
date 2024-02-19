using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstact
{
    public interface ICommentService
    {
        Task<IEnumerable<Comments>> GetAllCommentAsync(bool trackChanges);
        Task<CommentDTO> CreateComment(CommentCreateDTO comment);
        Task DeleteComment(int id, bool trackChanes);
        Task<Comments> GetCommentByIdAsync(int id, bool trackChanges);
    }
}
