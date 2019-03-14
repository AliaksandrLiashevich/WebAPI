using DAL.Interfaces.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(DataAccessCategory category);

        Task<DataAccessCategory> GetCategoryByIdAsync(int categoryId);

        Task<DataAccessCategory> GetAllCategoriesAsync();

        Task<DataAccessCategory> GetAllCategoryProductsAsync(int categoryId);
    }
}
