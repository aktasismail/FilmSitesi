using AutoMapper;
using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.DTO;
using EntitiesLayer.Exceptions;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public CommentManager(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public async Task<CommentDTO> CreateComment(CommentCreateDTO comment)
        {
            var entity = _mapper.Map<Comments>(comment);
            _repositoryManager.commentRepository.CreateComment(entity);
            await _repositoryManager.Save();
            return _mapper.Map<CommentDTO>(entity);
        }

        public async Task DeleteComment(int id, bool trackChanes)
        {
            var entity = _repositoryManager.commentRepository.GetOneCommentById(id, trackChanes);
            if (entity is null)
            {
                throw new MovieNotFoundException(id);
            }
            _repositoryManager.commentRepository.Delete(entity);
            await _repositoryManager.Save();
        }

        public async Task<IEnumerable<Comments>> GetAllCommentAsync(bool trackChanges)
        {
            return await _repositoryManager
                .commentRepository.GetAllComment(trackChanges);
        }
        public async Task<Comments> GetCommentByIdAsync(int id, bool trackChanges)
        {

            var comment = _repositoryManager.commentRepository
                .GetOneCommentById(id, trackChanges);

            if (comment is null)
                throw new GenreNotFoundException(id);
            return comment;
        }
    }
}
