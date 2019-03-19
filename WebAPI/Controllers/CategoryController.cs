using BLL.Interfaces;
using BLL.Interfaces.Models;
using DAL.Interfaces.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CreateCategory category)
        {
            try
            {
                await _service.AddCategoryAsync(category);

                return NoContent();
            }
            catch(DatabaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _service.GetCategoryByIdAsync(id);

                return Ok(category);
            }
            catch (DatabaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _service.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet("{id:int:min(1)}/products")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCategoryProductsAsync(int id)
        {
            try
            {
                var products = await _service.GetAllCategoryProductsAsync(id);

                return Ok(products);
            }
            catch (DatabaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int:min(1)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            try
            {
                await _service.DeleteCategoryAsync(id);

                return NoContent();
            }
            catch (DatabaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
