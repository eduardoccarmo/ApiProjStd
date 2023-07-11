using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Api.Proj.Std.Domain.ViewModels;
using Microsoft.Extensions.Logging;

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

        public async Task<Product> PostAsync(ProductCreateViewModel product)
        {
            int id = (int)await _productRepository.GetMaxID();

            var newProduct = new Product
            {
                Id = id,
                Name = product.Name,
                Brand = product.Brand,
                Category = product.Category,
                Price = product.Price,
                RegisterDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            var ret = _productRepository.PostAsync(newProduct);

            if (ret is not null)
                return newProduct;

            return null;
        }

        public async Task<Product> Put(Product product, int id)
        {
            var updateProduct = await _productRepository.GetById(id);

            if (updateProduct is not null)
            {
                updateProduct = PropertyIsChangeg(updateProduct, product);

                updateProduct = await _productRepository.Put(updateProduct);

                if (updateProduct is not null)
                    return updateProduct;
            }

            return null;
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

            if (!oldValue.Brand.Equals(newValue.Brand))
                updateProduct.Brand = newValue.Brand;

            if (!oldValue.Category.Equals(newValue.Category))
                updateProduct.Category = newValue.Category;

            if (!oldValue.Price.Equals(newValue.Price))
                updateProduct.Price = newValue.Price;

            updateProduct.LastUpdateDate = DateTime.Now;

            return updateProduct;
        }

        public async Task<Product> DeleteById(int id)
        {
            if (id > 0)
            {
                Product? product = await _productRepository.GetById(id);

                if (product is not null && product.Price < 1500)
                {
                    await _productRepository.DeleteById(product);
                    return product;
                }

                throw new Exception(message: "Cannot delete product because the price is more than 1500.");
            }

            return null;
        }
    }
}
