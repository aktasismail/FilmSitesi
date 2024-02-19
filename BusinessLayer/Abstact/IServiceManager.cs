using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstact
{
    public interface IServiceManager
    {
        IMovieService MovieService { get; }
        IGenreService GenreService { get; }
        ICommentService CommentService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
