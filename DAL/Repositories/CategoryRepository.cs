using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Interfaces;
using DAL.Interfaces.Entities;
using DAL.Interfaces.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DALContext _context;

        public CategoryRepository(DALContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(DataAccessCategory category)
        {
            var dbCategory = _context.Categories.Where(c => c.Name == category.Name).ToList();

            if (dbCategory.Count != 0)
            {
                throw new DatabaseException(DatabaseException.ErrorType.InvalidCategoryName,
                    "One of the categories in database has the same name");
            }

            _context.Add(category);

            await _context.SaveChangesAsync();
        }

        public async Task<DataAccessCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await Task.Run(() =>
            {
                var dbCategory = _context.Categories.Where(c => c.Id == categoryId).ToList();

                if (dbCategory.Count == 0)
                {
                    throw new DatabaseException(DatabaseException.ErrorType.InvalidCategoryId,
                        "Category doesn't exist");
                }

                return dbCategory[0];
            });
        }

        public async Task<List<DataAccessCategory>> GetAllCategoriesAsync()
        {
            return await Task.Run(() => _context.Categories.ToList());
        }

        public async Task<List<DataAccessProduct>> GetAllCategoryProductsAsync(int categoryId)
        {
            return await Task.Run(() =>
            {
                var dbCategories = _context.Categories.Include("Products");
                var dbCategory = dbCategories.Where(c => c.Id == categoryId).ToList();

                if (dbCategory.Count == 0)
                {
                    throw new DatabaseException(DatabaseException.ErrorType.InvalidCategoryId,
                        "Category doesn't exist");
                }

                return dbCategory[0].Products.ToList();
            });
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var dbCategory = _context.Categories.Where(c => c.Id == categoryId).ToList();

            if (dbCategory.Count == 0)
            {
                throw new DatabaseException(DatabaseException.ErrorType.InvalidCategoryId,
                    "Category doesn't exist");
            }

            _context.Categories.Remove(dbCategory[0]);

            await _context.SaveChangesAsync();
        }
    }
}
