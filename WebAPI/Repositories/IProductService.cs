using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Dto.ProductsDto;
using WebAPI.Models;
namespace WebAPI.Repositories;
public interface IProductService
{
    Task<ResponseModel<List<Product>>> GetAllProducts();
    Task<ResponseModel<Product>> GetProductById(int idProduct);
    Task<ResponseModel<Product>> UpdateProduct(UpdateProductDto updateProductDto);
    Task<ResponseModel<List<Product>>> CreateProduct(CreateProductDto createProductDto);
    Task<ResponseModel<Product>> DeleteProduct(int idProduct);
}
