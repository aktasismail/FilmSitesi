using AutoMapper;
using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.DTO;
using EntitiesLayer.Exceptions;
using EntitiesLayer.RequestFeature;
using System.Dynamic;

namespace BusinessLayer.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        public MovieManager(IRepositoryManager manager, ILogService logService, IMapper mapper)
        {
            _manager = manager;
            _logService = logService;
            _mapper = mapper;
        }
        public async Task<MovieDTO> CreateMovie(MovieCreatedDto movies)
        {
            var entity = _mapper.Map<Movies>(movies);
            _manager.movieRepository.CreateMovie(entity);
            await _manager.Save();
            return _mapper.Map<MovieDTO>(entity);
        }
        public async Task DeleteMovie(int id, bool trackChanes)
        {
            var entity = _manager.movieRepository.GetaMovie(id, trackChanes);
            if (entity is null)
            {
                throw new MovieNotFoundException(id);
            }
            _manager.movieRepository.Delete(entity);
            await _manager.Save();
        }
        public async Task<IEnumerable<MovieDTO>> GetAllMovie(MovieParameter movieParameter,bool trackChanges)
        {
            if (!movieParameter.ValidRate)
                throw new MovieNotFoundException(1);

            var movie = await _manager.movieRepository.GetAllMovie(movieParameter, trackChanges);

            var moviedto = _mapper.Map<IEnumerable<MovieDTO>>(movie);
            return (moviedto);
        }
        public async Task<MovieDTO> GetaMovie(int id, bool trackChanges)
        {
            var entity =  _manager.movieRepository.GetaMovie(id, trackChanges);
            if (entity is null)
             throw new MovieNotFoundException(id);
            return _mapper.Map<MovieDTO>(entity);
        }

        public async Task<IEnumerable<MovieDTO>> GetLastMovie(bool trackChanges)
        {
            var movie = _manager.movieRepository.GetLast(trackChanges).Result;
            var moviedto =  _mapper.Map<IEnumerable<MovieDTO>>(movie);
            return (moviedto);
        }
        public async Task UpdateMovie(int id,
            MovieUpdateDto bookDto,
            bool trackChanges)
        {
            var entity = await GetMovieById(id, trackChanges);
            entity = _mapper.Map<Movies>(bookDto);
            _manager.movieRepository.Update(entity);
            await _manager.Save();
        }
        private async Task<Movies> GetMovieById(int id, bool trackChanges)
        {
            //await
            var entity = _manager.movieRepository.GetaMovie(id, trackChanges);

            if (entity is null)
                throw new MovieNotFoundException(id);

            return entity;
        }
    }
}
