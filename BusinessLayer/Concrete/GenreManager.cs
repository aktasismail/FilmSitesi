using AutoMapper;
using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.DTO;
using EntitiesLayer.Exceptions;

namespace BusinessLayer.Concrete
{
    public class GenreManager :IGenreService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public GenreManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public async Task<GenreDTO> CreateGenre(GenreCreatedDTO genre)
        {
            var entity = _mapper.Map<Genres>(genre);
            _manager.genreRepository.CreateGenre(entity);
            await _manager.Save();
            return _mapper.Map<GenreDTO>(entity);
        }
        public async Task DeleteGenre(int id, bool trackChanes)
        {
            var entity = _manager.genreRepository.GetOneGenreById(id, trackChanes);
            if (entity is null)
            {
                throw new MovieNotFoundException(id);
            }
            _manager.genreRepository.Delete(entity);
            await _manager.Save();
        }

        public async Task<IEnumerable<Genres>> GetAllGenresAsync(bool trackChanges)
        {
            return await _manager
                .genreRepository.GetAllGenres(trackChanges);
        }

        public async Task UpdateGenre(int id, GenreDTO genre, bool trackChanges)
        {
            var entity = await GetGenreById(id, trackChanges);
            entity = _mapper.Map<Genres>(genre);
            _manager.genreRepository.Update(entity);
            await _manager.Save();
        }
        private async Task<Genres> GetGenreById(int id, bool trackChanges)
        {
            //await
            var entity = _manager.genreRepository.GetOneGenreById(id, trackChanges);

            if (entity is null)
                throw new MovieNotFoundException(id);

            return entity;
        }
    }
}
