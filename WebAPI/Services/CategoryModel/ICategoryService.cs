using WebAPI.Dto.CategoriesDto;
using WebAPI.Models;
namespace WebAPI.Services.CategoryModel;
public interface ICategoryService
{
    Task<ResponseModel<List<Category>>> GetAllCategories();
    Task<ResponseModel<Category>> GetCategoryById(int idCategory);
    Task<ResponseModel<Category>> UpdateCategory(UpdateCategoryDto updateCategoryDto);
    Task<ResponseModel<Category>> CreateCategory(CreateCategoryDto createCategoryDto);
    Task<ResponseModel<Category>> DeleteCategory(int idCategory);
}
