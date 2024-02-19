using AutoMapper;
using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<IMovieService> _movieService;
        private readonly Lazy<IGenreService> _genreService;
        private readonly Lazy<ICommentService> _commentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositorymanager,
            ILogService logService,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration
            )
        {
            _movieService = new Lazy<IMovieService>(() => new MovieManager(repositorymanager,logService,mapper));
            _genreService = new Lazy<IGenreService>(() => new GenreManager(repositorymanager,mapper));
            _commentService = new Lazy<ICommentService>(() => new CommentManager(mapper,repositorymanager));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logService, mapper, userManager, configuration));
        }
        public IMovieService MovieService => _movieService.Value;
        public ICommentService CommentService => _commentService.Value;
        public IGenreService GenreService => _genreService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
