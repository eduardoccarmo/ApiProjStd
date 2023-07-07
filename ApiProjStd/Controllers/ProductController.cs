using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Api.Proj.Std.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ApiProjStd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPut]
        [Route("Put/{id}")]
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
            catch(DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<string>(errors: $"An error has ocurred on update product: {ex.Message}."));
            }
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(Product product)
        {
            try
            {
                var newProduct = await _productService.PostAsync(product);

                if (newProduct != null)
                    return Created(nameof(Post), new ResultViewModel<dynamic>(
                        new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Brand = product.Brand,
                            Category = product.Category,
                            RegisterDate = product.RegisterDate,
                            LastUpdateDate = product.LastUpdateDate
                        }));

                return BadRequest(new ResultViewModel<string>(errors: "One error has ocurred when we trie to save the product"));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>(errors: $"An Error has ocurred: {ex.Message}."));
            }            
        }
    }
}
