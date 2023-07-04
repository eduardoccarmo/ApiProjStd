using Api.Proj.Std.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Interface
{
    public interface ICategoryService
    {
        public Task<Category> GetById(int id);

        public Task<Category> GetByName(string name);

        public Task<Category> AddCategory(Category category);

        public Task<List<Category>> GetAll();

        public int CategoryIsValid(Category category);
    }
}
