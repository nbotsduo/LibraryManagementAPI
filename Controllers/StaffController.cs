using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController (ILibraryRepository _repository) :ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetAll()
        {
            return Ok(await _repository.GetAllStaffAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetById(int id)
        {
            return Ok( await _repository.GetStaffAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<StaffDTO>> CreateStaff(CreateStaffDTO model) { 
            var result = await _repository.CreateStaffAsync(model);

            return CreatedAtAction(nameof(GetById), new {id=result.ID}, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StaffDTO>> UpdateStaff(int id,UpdateStaffDTO staff)
        {
            var result =await _repository.UpdateStaffAsync(id, staff);

            if (result == null) { NotFound("Staff not found based on the ID provided."); }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaff(int id) { 

            var delete =await _repository.DeleteStaffAsync(id);
            if(!delete) return NotFound();
            Response.Headers.Append("X-Status-Message", "Staff not found based on the ID provided.");
            return Ok("Staff deleted successuflly");
        }
    }
}
