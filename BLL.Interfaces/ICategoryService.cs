using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces.Models;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(Category category);

        Task<Category> GetCategoryByIdAsync(int categoryId);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<List<Product>> GetAllCategoryProductsAsync(int categoryId);
    }
}
