using Api.Prof.Std.Infra.Context;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Prof.Std.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiContext _context;

        public CategoryRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            var newCategory = new Category
            {
                Id = category.Id,
                Name = category.Name,
                RegisterDate = DateTime.Now
            };

            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return newCategory;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Task<Category> DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(category is not null)
                return category;

            return new Category(); 
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var category = await _context.Categories.FirstAsync(x => x.Name == name);

            if (category == null)
                return null;

            return category;
        }
    }
}
