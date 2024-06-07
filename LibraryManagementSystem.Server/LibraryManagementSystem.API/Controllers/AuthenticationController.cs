using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var token = await _authenticationService.Authenticate(model.Username, model.Password);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect." });

            return Ok(new { Token = token });
        }
    }
}