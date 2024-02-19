using BusinessLayer.Abstact;
using EntitiesLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Filters;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AccountController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUsers([FromBody] LoginDto loginDto)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(loginDto))
            {
                return Unauthorized();
            }
            var tokendto = await _serviceManager.AuthenticationService.CreateToken();
            return Ok(tokendto);
        }
        [HttpPost(Name = "Register")]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto)
        {
            var result = await _serviceManager.AuthenticationService.RegisterUser(registerDto);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.TryAddModelError(item.Code, item.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);

        }
        [HttpGet("LoginUsers")]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto user)
        {
            if (!await _serviceManager.AuthenticationService.ValidateUser(user))
                return Unauthorized(); // 401
            return Ok(new
            {
                Token = await _serviceManager
                .AuthenticationService
                .CreateToken()
        });
        }

    }
}
