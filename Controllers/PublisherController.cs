using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController (ILibraryRepository _repository) :ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Publisher>> GetAll()
        {
            var result = await _repository.GetAllPublisherAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetByID(int id) { 
            var result = await _repository.GetPublisherAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PublisherDTO>> CreatePublisher (CreatePublisherDTO create)
        {
            var result = await _repository.CreatePublisherAsync(create);
            return CreatedAtAction(nameof(GetByID), new { id = result.ID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PublisherDTO>> UpdatePublisher (int id,UpdatePublisherDTO update)
        {
            var result = await _repository.UpdatePublisherAsync(id,update);

            if (result == null) return NotFound("Publisher not found based on the ID provided.");

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePublisher(int id) {
            var delete = await _repository.DeletePublisherAsync(id);
            if (!delete) return NotFound("Publisher not found based on the ID provided.");
            Response.Headers.Append("X-Status-Message", "Publisher has been removed");
            return Ok("Publisher deleted successuflly");
        }
    }
}
