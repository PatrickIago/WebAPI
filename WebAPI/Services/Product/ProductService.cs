using Azure;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dto.ProductsDto;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services.ProductModel;
public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<List<Product>>> CreateProduct(CreateProductDto createProductDto)
    {
        ResponseModel<List<Product>> response = new ResponseModel<List<Product>>();
        try
        {
            var categoria = await _context.Categories
                  .FirstOrDefaultAsync(categoriaBanco => categoriaBanco.Id == createProductDto.Category.Id);
            if (categoria == null)
            {
                response.Mensagem = "Nenhuma categoria localizada";
                return response;
            }

            var product = new Product()
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Category = categoria
            };

            _context.Add(product);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Products.Include(p => p.Category).ToListAsync();
            response.Mensagem = "Produto Criado!";
            return response;
        }

        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }   
    }

    public async Task<ResponseModel<Product>> DeleteProduct(int idProduct)
    {
        ResponseModel<Product> response = new ResponseModel<Product>();
        try
        {
           var product = _context.Products
                .FirstOrDefault(p => p.Id == idProduct);

            if (product == null)
            {
                response.Mensagem = "Produto não encontrado!";
                response.Status = false;
                return response;
            }

            _context.Remove(product);
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

    public async Task<ResponseModel<List<Product>>> GetAllProducts()
    {
        ResponseModel<List<Product>> response = new ResponseModel<List<Product>>();
        try
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            response.Dados = products;
            response.Mensagem = "Produtos Encontrados!";
        }
        catch (Exception ex)
        {
            response.Mensagem = ex.Message;
            response.Status = false;
            return response;
        }
        return response;
    }

    public async Task<ResponseModel<Product>> GetProductById(int idProduct)
    {
        ResponseModel<Product> response = new ResponseModel<Product>();
        try
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == idProduct);
            if(product == null)
            {
                response.Mensagem = "Produto não encontrado!";
                response.Status = false;
                return response;
            }

            response.Dados = product;
            response.Mensagem = "Produto Encontrado!";
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

    public async Task<ResponseModel<Product>> UpdateProduct(UpdateProductDto updateProductDto)
    {
        ResponseModel<Product> response = new ResponseModel<Product>();
        try
        {
          var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == updateProductDto.Id);
            if(product == null)
            {
                response.Mensagem = "Produto não encontrado!";
                response.Status = false;
            }

            product.Name = updateProductDto.Name;
            product.Price = updateProductDto.Price;
           
            _context.Update(product);
            await _context.SaveChangesAsync();

            response.Dados = product;
            response.Mensagem = "Produto atualizado!";

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
