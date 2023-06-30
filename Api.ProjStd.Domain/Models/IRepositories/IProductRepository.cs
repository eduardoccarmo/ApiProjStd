using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.Models.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task UpdateProdctAsync(int id);
        Task DeleteProdctAsync(int id);
    }
}
