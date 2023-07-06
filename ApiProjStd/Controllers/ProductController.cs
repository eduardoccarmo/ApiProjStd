using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.Models.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var updateProduct = await _productService.Put(product, id);

            if (updateProduct != null)
                return Ok(updateProduct);

            return BadRequest();
        }
    }
}
