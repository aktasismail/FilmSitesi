using BusinessLayer.Abstact;
using EntitiesLayer.DTO;
using EntitiesLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly IServiceManager _services;

        public CommentController(IServiceManager services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCommentAsync()
        {
            return Ok(await _services
                .CommentService
                .GetAllCommentAsync(false));
        }
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentCreateDTO comment)
        {
            if (comment is null)
                return BadRequest();
            await _services.CommentService.CreateComment(comment);
            return StatusCode(201, comment);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _services.CommentService.DeleteComment(id, false);
            return NoContent();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentByMovieId([FromRoute] int id)
        {
            return Ok( _services
                .CommentService
                .GetAllCommentAsync(false).Result.Where(x=>x.MovieId.Equals(id)));
        }
    }
}
