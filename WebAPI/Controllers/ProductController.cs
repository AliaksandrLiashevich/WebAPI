using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Interfaces.Models;
using Microsoft.AspNetCore.Http;
using DAL.Interfaces.Exceptions;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProductAsync([FromBody] CreateProduct product)
        {
            try
            {
                await _service.AddProductAsync(product);

                return NoContent();
            }
            catch (DatabaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _service.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id:int:min(1)}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _service.GetProductByIdAsync(id);

                return Ok(product);
            }
            catch (DatabaseException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
