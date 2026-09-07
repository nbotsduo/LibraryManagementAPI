using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController (ILibraryRepository _repository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Book>> GetAll() { 
            return Ok(await _repository.GetAllBooksAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>> GetByID(int id) {
            return Ok(await _repository.GetBookAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> CreateBook (CreateBookDTO create)
        {
            var result = await _repository.CreateBookAsync(create);
            if(result == null)
            {
                return BadRequest(new
                {
                    message = "Failed create book record",
                    errors =new {
                        category = "Category not exist",
                        publisher = "Publisher not exist",
                        author = "Author not exist"
                    }
                });
            }

            return CreatedAtAction(nameof(GetByID),new {id=result.ID},result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDTO>> UpdateBook(int id, UpdateBookDTO update) {
            var result = await _repository.UpdateBookAsync(id, update);

            if (result == null)
            {
                return BadRequest(new
                {
                    message = "Failed create book record",
                    errors = new
                    {
                        category = "Category not exist",
                        publisher = "Publisher not exist",
                        author = "Author not exist"
                    }
                });
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id) { 
            var delete = await _repository.DeleteBookAsync(id);

            //TODO: check if delete fails because bookcopies exist
            if (!delete) return NotFound();
            Response.Headers.Append("X-Status-Message", "Book not found based on the ID provided.");
            return Ok("Book deleted successuflly");
        }

    }
}
