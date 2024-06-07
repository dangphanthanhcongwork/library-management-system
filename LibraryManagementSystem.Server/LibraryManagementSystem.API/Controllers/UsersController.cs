using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;

namespace LibraryManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        // GET: api/users
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        // GET: api/users/{id}
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById(Guid id)
        {
            try
            {
                var user = await _service.GetByIdAsync(id);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/users
        [Authorize(Roles = "Librarian")]
        [HttpPost]
        public async Task<IActionResult> Post(UserRequest userRequest)
        {
            await _service.AddAsync(userRequest);
            return CreatedAtAction(nameof(GetById), new { id = Guid.NewGuid() }, userRequest);
        }

        // PUT: api/users/{id}
        [Authorize(Roles = "Librarian")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UserRequest userRequest)
        {
            try
            {
                await _service.UpdateAsync(id, userRequest);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/users/{id}
        [Authorize(Roles = "Librarian")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}