using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto.CategoriesDto;
using WebAPI.Dto.ProductsDto;
using WebAPI.Models;
using WebAPI.Services.CategoryModel;
using WebAPI.Services.ProductModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<ResponseModel<List<Category>>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("GetCategoryById")]
        public async Task<ActionResult<ResponseModel<Category>>> GetCategoryById(int idCategory)
        {
            var category = await _categoryService.GetCategoryById(idCategory);
            return Ok(category);
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult<ResponseModel<Category>>> CreateProduct(CreateCategoryDto createCategoryDto)
        {
            var category = await _categoryService.CreateCategory(createCategoryDto);
            return Ok(category);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<ResponseModel<Category>>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryService.UpdateCategory(updateCategoryDto);
            return Ok(category);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<ActionResult<ResponseModel<Category>>> DeleteCategory(int idCategory)
        {
            var product = await _categoryService.DeleteCategory(idCategory);
            return Ok();
        }
    }
}
