using AutoMapper;
using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.DTO;
using EntitiesLayer.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
  
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public MovieController(IServiceManager service, IRepositoryManager repositoryManager, IMapper mapper)
        {
            _service = service;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        [HttpGet(Name = "GetAllMovies")]
        public async Task<IActionResult> GetAllMovies([FromQuery] MovieParameter moviePageParameter)
        {
            var pagedResult = await _service.MovieService.GetAllMovie(moviePageParameter, false);
            return Ok(pagedResult);

        }
        [HttpPost(Name ="AddMovie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieCreatedDto movies)
        {
            if (movies is null)
                return BadRequest();
            await _service.MovieService.CreateMovie(movies);
            return StatusCode(201,movies);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id,
            [FromBody] MovieUpdateDto bookDto)
        {
            await _service.MovieService.UpdateMovie(id, bookDto, false);
            return NoContent(); // 204
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            await _service.MovieService.DeleteMovie(id,false);
            return NoContent();
        }
        [HttpOptions]
        public IActionResult GetMoviesOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS, HEAD");
            return Ok();
        }
        [HttpGet("GetLastMovie")]
        [Authorize]
        public async Task<IActionResult> GetLastMovie()
        {
            var movies =await _service.MovieService.GetLastMovie(false);
            return Ok(movies);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> MovieDetail(int id)
        {
            var DetailVM = new DetailVM()
            {
                movietDto =  _mapper.Map<MovieDTO>(_repositoryManager.movieRepository.GetaMovie(id, false))
            };
            return Ok(DetailVM);
        }

    }
}
