using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/categories
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet]
        public async Task<ActionResult<CategoryResponse>> GetAll()
        {
            var categories = await _service.GetAllAsync();

            return Ok(categories);
        }

        // GET: api/categories/{id}
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetById(Guid id)
        {
            try
            {
                var category = await _service.GetByIdAsync(id);

                return Ok(category);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Librarian")]
        [HttpPost]
        public async Task<IActionResult> Post(CategoryRequest categoryRequest)
        {
            await _service.AddAsync(categoryRequest);

            return CreatedAtAction(nameof(GetById), new { id = Guid.NewGuid() }, categoryRequest);
        }

        // PUT: api/categories/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Librarian")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, CategoryRequest categoryRequest)
        {
            try
            {
                await _service.UpdateAsync(id, categoryRequest);

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

        // DELETE: api/categories/{id}
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