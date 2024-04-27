using WebAPI.Models;
namespace WebAPI.Dto.ProductsDto;
public class CreateProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}
