using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController (ILibraryRepository _repository) :ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetAll()
        {
            return Ok(await _repository.GetAllMemberAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetByID(int id) { 
            return Ok(await _repository.GetMemberAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<MemberDTO>> CreateMember (CreateMemberDTO member)
        {
            var result = await _repository.CreateMemberAsync(member);

            return CreatedAtAction(nameof(GetByID), new { id = result.ID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MemberDTO>> UpdateMember(int id,UpdateMemberDTO member) { 
            var result = await _repository.UpdateMemberAsync(id,member);
            if (result == null) return NotFound("Member not found based on the ID provided.");

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMember(int id) { 
            var delete = await _repository.DeleteMemberAsync(id);
            if (!delete) return NotFound("Member not found based on the ID provided.");
            Response.Headers.Append("X-Status-Message", "Member has been removed.");
            return Ok("Member deleted successuflly");
        }
    }
}
