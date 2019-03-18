using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Interfaces;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Exceptions;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DALContext _context;

        public ProductRepository(DALContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(DataAccessProduct product)
        {
            var dbProduct = _context.Products.Where(p => p.Name == product.Name).ToList();

            if (dbProduct.Count != 0)
            {
                throw new DatabaseException(DatabaseException.ErrorType.InvalidProductName,
                        "One of the products in database has the same name");
            }

            _context.Add(product);

            await _context.SaveChangesAsync();
        }

        public async Task<List<DataAccessProduct>> GetAllProductsAsync()
        {
            return await Task.Run(() => _context.Products.ToList());
        }

        public async Task<DataAccessProduct> GetProductByIdAsync(int productId)
        {
            return await Task.Run(() =>
            {
                var dbProduct = _context.Products.Where(p => p.Id == productId).ToList();

                if (dbProduct.Count == 0)
                {
                    throw new DatabaseException(DatabaseException.ErrorType.InvalidCategoryId,
                        "Product doesn't exist");
                }

                return dbProduct[0];
            });
        }
    }
}
