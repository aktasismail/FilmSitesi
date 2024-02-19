using BusinessLayer.Abstact;
using EntitiesLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IServiceManager _services;

        public GenreController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenreAsync()
        {
            return Ok(await _services
                .GenreService
                .GetAllGenresAsync(false));
        }
        [HttpPost(Name = "AddGenre")]
        public async Task<IActionResult> AddGenre([FromBody] GenreCreatedDTO genre)
        {
            if (genre is null)
                return BadRequest();
            await _services.GenreService.CreateGenre(genre);
            return StatusCode(201, genre);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGenre([FromRoute(Name = "id")] int id,
            [FromBody] GenreDTO genreDTO)
        {
            await _services.GenreService.UpdateGenre(id, genreDTO, false);
            return NoContent(); // 204
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _services.GenreService.DeleteGenre(id, false);
            return NoContent();
        }
    }
}
