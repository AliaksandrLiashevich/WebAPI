using AutoMapper;
using BLL.Interfaces;
using BLL.Interfaces.Models;
using DAL.Interfaces;
using DAL.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            var dbCategory = Mapper.Map<DataAccessCategory>(category);

            await _repository.AddCategoryAsync(dbCategory);
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var dbCategory = await _repository.GetCategoryByIdAsync(categoryId);

            return Mapper.Map<Category>(dbCategory);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var dbCategories = await _repository.GetAllCategoriesAsync();

            return Mapper.Map<List<Category>>(dbCategories);
        }

        public async Task<List<Product>> GetAllCategoryProductsAsync(int categoryId)
        {
            var dbCategoryProducts = await _repository.GetCategoryByIdAsync(categoryId);

            return Mapper.Map<List<Product>>(dbCategoryProducts);
        }
    }
}
