using BLL.Interfaces;
using BLL.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
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
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _service.GetCategoryByIdAsync(categoryId);
        }

        [HttpGet]
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _service.GetAllCategoriesAsync();
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<List<Product>> GetAllCategoryProductsAsync(int categoryId)
        {
            return await _service.GetAllCategoryProductsAsync(categoryId);
        }
    }
}
