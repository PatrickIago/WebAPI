using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.CategoriesDto;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services.CategoryModel;
public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context; 
    public CategoryService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<Category>> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        ResponseModel<Category> response = new ResponseModel<Category>();
        try
        {
            var category = new Category()
            {
                Name = createCategoryDto.Name,
            };

            _context.Add(category);
            await _context.SaveChangesAsync();
            response.Dados = category;
            response.Mensagem = "Categoria Criada!";
            return response;
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<Category>> DeleteCategory(int idCategory)
    {
        ResponseModel<Category> response = new ResponseModel<Category>();
        try
        {
            var category = _context.Categories
                .FirstOrDefault(c => c.Id == idCategory);

            if (category == null)
            {
                response.Status = false;
                response.Mensagem = "Categoria não encontrada";
                return response;
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            response.Mensagem = "Produto excluido!";
            return response;

        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
        return response;
    }

    public async Task<ResponseModel<List<Category>>> GetAllCategories()
    {
        ResponseModel<List<Category>> response = new ResponseModel<List<Category>>();
        try
        {
            var categories = await _context.Categories
                .Include(c => c.Products) // Incluindo os produtos relacionados à categoria
                .ToListAsync();

            if (categories == null)
            {
                response.Mensagem = "Nenhuma Categoria Encontrada.";
                response.Status = false;
                return response;
            }

            response.Dados = categories;
            response.Mensagem = "Categorias Encontradas!";
            return response;
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
        return response;
    }

    public async Task<ResponseModel<Category>> GetCategoryById(int idCategory)
    {
        ResponseModel<Category> response = new ResponseModel<Category>();
        try
        {
          var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == idCategory);
            response.Dados = category;
            response.Mensagem = "Categoria encontrada!";
            return response;
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
        return response;
    }

    public async Task<ResponseModel<Category>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        ResponseModel<Category> response = new ResponseModel<Category>();
        try
        {
            var category = await _context.Categories.SingleOrDefaultAsync(p => p.Id == updateCategoryDto.Id);
            if (category == null)
            {
                response.Mensagem = "Categoria não encontrada!";
                response.Status = false;
            }

             category.Name = updateCategoryDto.Name;
            _context.Update(category);
            await _context.SaveChangesAsync();

            response.Dados = category;
            response.Mensagem = "Categoria atualizada!";

            return response;
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
        return response;
    }
}
