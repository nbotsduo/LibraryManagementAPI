using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookCopiesController(ILibraryRepository _repository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<BookCopy>>> GetAll()
        {
            return Ok(await _repository.GetAllBookCopiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookCopy>> GetByID(int id) { 
            return Ok(await _repository.GetBookCopyAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<BookCopiesDTO>> CreateBookCopies(CreateBookCopiesDTO book)
        {
            var result = await _repository.CreateBookCopyAsync(book);
            return CreatedAtAction(nameof(GetByID),new {id = result.ID}, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookCopiesDTO>> UpdateBookCopies(int id, UpdateBookCopiesDTO book) { 
            var result = await _repository.UpdateBookCopyAsync(id,book);
            if (result == null) return NotFound("Book copy not found based on the ID provided.");

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBookCopies(int id) { 
            var delete =await _repository.DeleteBookCopyAsync(id);
            if (!delete) return NotFound("Book copy not found based on the ID provided.");
            Response.Headers.Append("X-Status-Message", "Book copy has been removed.");
            return Ok("Book copy deleted successuflly");
        }

    }
}
