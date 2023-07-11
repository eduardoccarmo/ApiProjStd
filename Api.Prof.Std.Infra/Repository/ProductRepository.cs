using Api.Prof.Std.Infra.Context;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Api.Prof.Std.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext _context;

        public ProductRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<Product> DeleteById(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
                public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();

            products = await _context
                            .Products
                            .AsNoTracking()
                            .ToListAsync();

            if (products is not null)
                return products;

            return null;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _context
                                .Products
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

            if (product is not null)
                return product;

            return null;
        }

        public async Task<long> GetMaxID()
        {
            long id;

            id = _context
                .Products
                .Select(x => x.Id)
                .Max(x => x.Value);

            return id + 1;
        }

        public async Task<Product> PostAsync(Product product)
        {
            var newProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                RegisterDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return newProduct;
        }

        public async Task<Product> Put(Product product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
