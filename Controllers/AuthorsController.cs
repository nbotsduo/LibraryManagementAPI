using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController (ILibraryRepository _repository) : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Author>>> GetAll()
        {
            var result = await _repository.GetAllAuthorsAsync();
            return Ok(result);
        }

        //[HttpGet]
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetByID(int id)
        {

            var result = await _repository.GetAuthorsAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> CreateAuthor(CreateAuthorDTO author)
        {
            var result = await _repository.CreateAuthorAsync(author);
            //return Ok(result);
            return CreatedAtAction(nameof(GetByID), new { id = result.ID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDTO>> UpdateAuthor(int id, UpdateAuthorDTO author) {
            var result = await _repository.UpdateAuthorAsync(id, author);

            if(result == null) return NotFound("Author not found based on the ID provided.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            var delete = await _repository.DeleteAuthorAsync(id);
            if (!delete) return NotFound("Author not found based on the ID provided.");
            Response.Headers.Append("X-Status-Message", "Author has been removed.");
            return Ok("Category deleted successuflly");
        }
    }
}
