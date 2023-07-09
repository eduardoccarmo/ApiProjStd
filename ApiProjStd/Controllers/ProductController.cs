using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Extensions;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Api.Proj.Std.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ApiProjStd.Controllers
{
    [Route("v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPut]
        [Route("PutAsync/{id}")]
        public async Task<IActionResult> PutAsync(Product product, int id)
        {
            try
            {
                var updateProduct = await _productService.Put(product, id);

                if (updateProduct != null)
                    return Ok(new ResultViewModel<dynamic>(
                             new Product
                             {
                                 Id = product.Id,
                                 Name = product.Name,
                                 Brand = product.Brand,
                                 Category = product.Category,
                                 RegisterDate = product.RegisterDate,
                                 LastUpdateDate = product.LastUpdateDate
                             }));

                return BadRequest(new ResultViewModel<string>(errors: "An error has ocurred on update product."));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<DbUpdateException>(errors: $"An error has ocurred on update product: {ex.Message}."));
            }
        }

        [HttpPost]
        [Route("PostAsync")]
        public async Task<IActionResult> Post(ProductCreateViewModel product)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Product>(errors: ModelState.GetErrors()));

            try
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Brand = product.Brand,
                    Category = product.Category,
                    RegisterDate = product.RegisterDate,
                    LastUpdateDate = product.LastUpdateDate
                };

                if (newProduct != null)
                    return Created($"PostAsync/{newProduct.Id}", new ResultViewModel<dynamic>(
                        new Product
                        {
                            Id = newProduct.Id,
                            Name = newProduct.Name,
                            Brand = newProduct.Brand,
                            Category = newProduct.Category,
                            RegisterDate = newProduct.RegisterDate,
                            LastUpdateDate = newProduct.LastUpdateDate
                        }));

                return BadRequest(new ResultViewModel<Product>(errors: "There was an error on updating the product."));
            }
            catch (FormatException ex)
            {
                return BadRequest(new ResultViewModel<ProductCreateViewModel>(errors: ModelState.GetErrors()));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Product>(errors: $"An error has ocurred on update product: {ex.Message}."));
            }
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();

            if (products is not null)
                return Ok(products);

            return NotFound(new ResultViewModel<string>(errors: "Products not found."));
        }

        [HttpGet]
        [Route("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _productService.GetById(id);

            if (product is not null)
                return Ok(product);

            return NotFound(new ResultViewModel<string>(errors: "Product not found."));
        }
    }
}
