using Api.Prof.Std.Infra.Repository;
using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> AddCategory(Category category)
        {
            if (category != null)
            {
                int categoryIsValid = CategoryIsValid(category);

                if (categoryIsValid > 0)
                {
                    var newCategory = _categoryRepository.AddCategory(category);

                    return newCategory;
                }
            }
            return null;
        }

        public Task<List<Category>> GetAll()
        {
            var categories = _categoryRepository.GetAllCategories();

            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);

            if (category == null)
                return null;

            return category;
        }

        public async Task<Category> GetByName(string name)
        {
            if (name is not null)
            {
                var category = await _categoryRepository.GetCategoryByName(name);
                return category;
            }

            return null;
        }

        public int CategoryIsValid(Category category)
        {
            if (category.Name == null || category.RegisterDate == null)
                return -1;

            return 1;
        }
    }
}
