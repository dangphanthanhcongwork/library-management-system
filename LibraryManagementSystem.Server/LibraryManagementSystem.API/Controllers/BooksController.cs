using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: api/books
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet]
        public async Task<ActionResult<BookResponse>> GetAll()
        {
            var books = await _service.GetAllAsync();

            return Ok(books);
        }

        // GET: api/books/{id}
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> GetById(Guid id)
        {
            try
            {
                var book = await _service.GetByIdAsync(id);

                return Ok(book);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Librarian")]
        [HttpPost]
        public async Task<IActionResult> Post(BookRequest bookRequest)
        {
            await _service.AddAsync(bookRequest);

            return CreatedAtAction(nameof(GetById), new { id = Guid.NewGuid() }, bookRequest);
        }

        // PUT: api/books/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Librarian")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, BookRequest bookRequest)
        {
            try
            {
                await _service.UpdateAsync(id, bookRequest);

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

        // DELETE: api/books/{id}
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