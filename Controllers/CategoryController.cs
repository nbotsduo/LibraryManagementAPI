using LibraryManagementSystemAPI.DTO;
using LibraryManagementSystemAPI.Entities;
using LibraryManagementSystemAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController (ILibraryRepository _repository): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Category>> GetAll()
        {
            var result = await _repository.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetByID(int id)
        {
            var result = await _repository.GetCategoriesAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CreateCategoryDTO categoryDTO)
        {
            var result = await _repository.CreateCategoryAsync(categoryDTO);

            return CreatedAtAction(nameof(GetByID), new { id = result.ID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id,UpdateCategoryDTO categoryDTO) {
            var result = await _repository.UpdateCategoryAsync(id, categoryDTO);

            if (result == null) return NotFound("Category not found based on the ID provided.");

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id) { 
            var delete = await _repository.DeleteCategoryAsync(id);
            if(!delete) return NotFound("Category not found based on the ID provided.");
            Response.Headers.Append("X-Status-Message", "Category has been removed.");
            return Ok("Category deleted successuflly");
        }
    }
}
