using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController(ILibraryRepository _repository) : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Loan>>> GetAll()
        {
            var result = await _repository.GetAllLoansAsync();
            return Ok(result);
        }

        //[HttpGet]
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetByID(int id)
        {

            var result = await _repository.GetLoanAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDTO>> CreateLoan(CreateLoanDTO loan)
        {
            var result = await _repository.CreateLoanAsync(loan);
            //return Ok(result);
            return CreatedAtAction(nameof(GetByID), new { id = result.ID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LoanDTO>> UpdateLoan(int id, UpdateLoanDTO loan)
        {
            var result = await _repository.UpdateLoanDTOAsync(id, loan);

            if (result == null) return NotFound("Loan not found based on the ID provided.");

            return Ok(result);
        }

        [HttpPut("{id}/extend")]
        public async Task<ActionResult<LoanDTO>> UpdateExtend(int id)
        {
            var result = await _repository.ExtendLoanAsync(id);

            if (result == null) return NotFound("Loan not found based on the ID provided.");

            return Ok(result);
        }

        [HttpPut("{id}/Return")]
        public async Task<ActionResult<LoanDTO>> ReturnLoan(int id)
        {
            var result = await _repository.ReturnLoanAsync(id);

            if (result == null) return NotFound("Loan not found based on the ID provided.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            var delete = await _repository.DeleteLoanAsyncs(id);
            if (!delete) return NotFound("Loan not found based on the ID provided.");
            Response.Headers.Append("X-Status-Message", "Loan has been removed.");
            return Ok("Loan deleted successuflly");
        }
    }
}
