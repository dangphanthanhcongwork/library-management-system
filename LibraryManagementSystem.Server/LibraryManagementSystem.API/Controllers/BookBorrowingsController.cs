using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagementSystem.API.Controllers
{
    [Route("api/book-borrowings")]
    [ApiController]
    public class BookBorrowingsController : ControllerBase
    {
        private readonly IBookBorrowingService _service;

        public BookBorrowingsController(IBookBorrowingService service)
        {
            _service = service;
        }

        // GET: api/book-borrowings
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet]
        public async Task<ActionResult<BookBorrowingResponse>> GetAll()
        {
            var bookBorrowings = await _service.GetAllAsync();

            return Ok(bookBorrowings);
        }

        // GET: api/book-borrowings/{id}
        [Authorize(Roles = "Librarian, Member")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookBorrowingResponse>> GetById(Guid id)
        {
            try
            {
                var bookBorrowing = await _service.GetByIdAsync(id);

                return Ok(bookBorrowing);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/book-borrowings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Post(BookBorrowingRequest bookBorrowingRequest)
        {
            try
            {
                await _service.AddAsync(bookBorrowingRequest);

                return CreatedAtAction(nameof(GetById), new { id = Guid.NewGuid() }, bookBorrowingRequest);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/book-borrowings/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Member")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, BookBorrowingRequest bookBorrowingRequest)
        {
            try
            {
                await _service.UpdateAsync(id, bookBorrowingRequest);

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

        // DELETE: api/book-borrowings/{id}
        [Authorize(Roles = "Member")]
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

        // POST: api/book-borrowings/request
        [Authorize(Roles = "Member")]
        [HttpPost("request")]
        public async Task<IActionResult> RequestBookBorrowing(BookBorrowingRequest bookBorrowingRequest)
        {
            try
            {
                await _service.RequestAsync(bookBorrowingRequest);
                return CreatedAtAction(nameof(GetById), new { id = Guid.NewGuid() }, bookBorrowingRequest);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/book-borrowings/approve/{id}
        [Authorize(Roles = "Librarian")]
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApproveBookBorrowing(Guid id, BookBorrowingRequest bookBorrowingRequest)
        {
            try
            {
                await _service.ApproveAsync(id, bookBorrowingRequest);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}