using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Interfaces.Models;

namespace WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddProductAsync([FromBody] Product product)
        {
            await _service.AddProductAsync(product);
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _service.GetAllProductsAsync();
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _service.GetProductByIdAsync(id);
        }
    }
}
