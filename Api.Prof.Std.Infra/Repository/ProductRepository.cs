using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Prof.Std.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProdctAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProdctAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
