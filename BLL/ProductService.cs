using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Interfaces.Models;
using DAL.Interfaces;
using DAL.Interfaces.Entities;

namespace BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProductAsync(Product product)
        {
            var dbProduct = Mapper.Map<DataAccessProduct>(product);

            await _repository.AddProductAsync(dbProduct);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var dbProducts = await _repository.GetAllProductsAsync();

            return Mapper.Map<List<Product>>(dbProducts);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var dbProduct = await _repository.GetProductByIdAsync(productId);

            return Mapper.Map<Product>(dbProduct);
        }
    }
}
