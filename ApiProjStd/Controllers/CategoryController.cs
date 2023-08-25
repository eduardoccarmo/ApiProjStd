using Api.Proj.Std.Application.Interface;
using Api.Proj.Std.Domain.Models;
using Api.Proj.Std.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Common;

namespace ApiProjStd.Controllers
{
    [Route("v1/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = new List<Category>();

            categories = await _categoryService.GetAll();

            if (categories is not null)
                return Ok(categories);

            return StatusCode(400, new ResultViewModel<string>(errors: "Categories not found."));
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoryService.GetById(id);

                if (category == null)
                    return NotFound(new ResultViewModel<string>(errors: "Category not found."));

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbException msg)
            {
                return StatusCode(400, new ResultViewModel<string>(errors: $"ExDb01: DatabaseError: {msg.Message}."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>(errors: $"ExGr01: An error has ocurred: {ex.Message}."));
            }
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var category = await _categoryService.GetByName(name.ToUpper());

                if (category == null)
                    return NotFound(new ResultViewModel<string>(errors: "Category not found."));

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbException msg)
            {
                return StatusCode(400, new ResultViewModel<string>(errors: $"ExDb02: DatabaseError: {msg.Message}."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>(errors: $"ExGr02: An error has ocurred: {ex.Message}."));
            }

        }

        [HttpPost]
        [Route("v1/PostCategory")]
        public async Task<IActionResult> PostCategory(Category category)
        {
            try
            {
                var newCategory = await _categoryService.AddCategory(category);

                return Created("v1/PostCategory", new ResultViewModel<dynamic>(
                    new Category
                    {
                        Id = category.Id,
                        Name = category.Name,
                        RegisterDate = category.RegisterDate,
                    }));
            }
            catch (DbException msg)
            {
                return StatusCode(400, new ResultViewModel<string>(errors: $"ExDb03: DataBaseError{msg.Message}"));
            }
        }

        [HttpPut]
        [Route("PutCategory/{id}")]
        public async Task<IActionResult> PutCategory(Category category, int id)
        {
            try
            {
                var updateCategory = await _categoryService.UpdateCategory(category, id);

                if (updateCategory is not null)
                {
                    return Ok(new ResultViewModel<dynamic>(
                        new Category
                        {
                            Id = updateCategory.Id,
                            Name = updateCategory.Name,
                            RegisterDate = updateCategory.RegisterDate
                        }));
                }

                return NotFound(new ResultViewModel<string>(errors:"Category not found."));
            }
            catch(DbUpdateException ex)
            {
                return StatusCode(400, new ResultViewModel<string>(errors: $"ExDb04 - Data base update error:{ex.Message}"));
            }
        }
    }
}
