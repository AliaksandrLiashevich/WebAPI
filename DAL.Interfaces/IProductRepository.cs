using DAL.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(DataAccessProduct product);

        Task<DataAccessProduct> GetProductByIdAsync(int productId);

        Task<List<DataAccessProduct>> GetAllProductsAsync();

        Task DeleteProductAsync(int productId);
    }
}
