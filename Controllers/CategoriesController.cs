using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BackEnd.SuperMarket.DTOs;
using BackEnd.SuperMarket.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackEnd.SuperMarket.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int pageSize = 10, string searchQuery = "")
        {
            var response = await _service.GetCategoriesAsync(page, pageSize,searchQuery);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetCategoryAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CategoryAddDto category)
        {
            var productId = await _service.CreateCategoryAsync(category);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CategoryDto category)
        {
            await _service.UpdateCategoryAsync(id, category);
            if (id != category.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}