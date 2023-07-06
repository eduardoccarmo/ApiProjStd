using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<Product> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> PostAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Put(Product product, int id)
        {
            throw new NotImplementedException();
        }
    }
}
