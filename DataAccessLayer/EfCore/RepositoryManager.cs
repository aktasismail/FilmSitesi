using DataAccessLayer.Abstract;

namespace DataAccessLayer.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly MovieDbContext _context;
        private readonly Lazy<IMovieRepository> _movieRepository;
        private readonly Lazy<IGenreRepository> _genreRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;
        public RepositoryManager(MovieDbContext? context)
        {
            _context = context;
            _movieRepository = new Lazy<IMovieRepository>(() => new MovieRepository(_context));
            _genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(_context));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(_context));
        }
        public IMovieRepository movieRepository => _movieRepository.Value;

        public IGenreRepository genreRepository => _genreRepository.Value;
        public ICommentRepository commentRepository => _commentRepository.Value;

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
