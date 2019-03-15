using BLL.Interfaces;
using BLL.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task AddCategoryAsync([FromBody] Category category)
        {
            await _service.AddCategoryAsync(category);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _service.GetCategoryByIdAsync(id);
        }

        [HttpGet]
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _service.GetAllCategoriesAsync();
        }

        [HttpGet("{id:int:min(1)}/products")]
        public async Task<List<Product>> GetAllCategoryProductsAsync(int categoryId)
        {
            return await _service.GetAllCategoryProductsAsync(categoryId);
        }
    }
}
