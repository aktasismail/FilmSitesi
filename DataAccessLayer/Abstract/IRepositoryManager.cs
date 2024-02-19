namespace DataAccessLayer.Abstract
{
    public interface IRepositoryManager
    {
        IMovieRepository movieRepository { get; }
        IGenreRepository genreRepository { get; }
        ICommentRepository commentRepository { get; }
        Task Save();
    }
}
