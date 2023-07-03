using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.Models.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> DeleteCategory(int categoryId);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryByName(string name);
        Task<Category> GetCategoryById(int id);
        Task<Category> AddCategory(Category category);
    }
}
