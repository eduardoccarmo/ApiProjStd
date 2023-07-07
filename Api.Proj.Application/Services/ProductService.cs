using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            if (products is not null)
                return products;

            return null;
        }

        public async Task<Product> GetById(int id)
        {
            if (id == null || id < 0)
                return null;

            var product = await _productRepository.GetById(id);

            if (product is null)
                return null;

            return product;
        }

        public async Task<Product> PostAsync(Product product)
        {
            var result = ProductIsValid(product);

            if(result > 0)
            {
                var newProduct = await _productRepository.PostAsync(product);

                if (newProduct is not null)
                    return newProduct;
            }
            return null; 
        }

        public async Task<Product> Put(Product product, int id)
        {
            var updateProduct = await _productRepository.GetById(id); 

            if(updateProduct is not null)
            {
                var isValid = ProductIsValid(product);

                if (isValid > 0)
                {
                    updateProduct = PropertyIsChangeg(updateProduct, product);

                    updateProduct = await _productRepository.Put(updateProduct);

                    if (updateProduct is not null)
                        return updateProduct;

                    return new Product();
                }
                return new Product();                    
            }
            return new Product();
        }

        public int ProductIsValid(Product product)
        {
            if (product.Name == null || product.Brand == null || product.Category == null
                || product.Category == null || product.LastUpdateDate == null)
                return -1;

            return 1;
        }
        
        public Product PropertyIsChangeg(Product oldValue, Product newValue)
        {
            var updateProduct = new Product
            {
                Id = oldValue.Id,
                Name = oldValue.Name,
                Brand = oldValue.Brand,
                Category = oldValue.Category,
                Price = oldValue.Price,
                RegisterDate = oldValue.RegisterDate,
                LastUpdateDate = oldValue.LastUpdateDate
            };

            if (!oldValue.Name.Equals(newValue.Name))
                updateProduct.Name = newValue.Name;
           
            if(!oldValue.Brand.Equals(newValue.Brand))
                updateProduct.Brand = newValue.Brand;
            
            if(!oldValue.Category.Equals(newValue.Category))
                updateProduct.Category = newValue.Category;

            if (!oldValue.Price.Equals(newValue.Price))
                updateProduct.Price = newValue.Price;

            updateProduct.LastUpdateDate = DateTime.Now;

            return updateProduct;
        }
    }
}
