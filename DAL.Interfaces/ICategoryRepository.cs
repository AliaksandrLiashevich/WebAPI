using DAL.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(DataAccessCategory category);

        Task<DataAccessCategory> GetCategoryByIdAsync(int categoryId);

        Task<List<DataAccessCategory>> GetAllCategoriesAsync();

        Task<List<DataAccessProduct>> GetAllCategoryProductsAsync(int categoryId);

        Task DeleteCategoryAsync(int categoryId);
    }
}
