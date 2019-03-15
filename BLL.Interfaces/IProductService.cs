﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Models;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);

        Task<Product> GetProductByIdAsync(int productId);

        Task<List<Product>> GetAllProductsAsync();
    }
}