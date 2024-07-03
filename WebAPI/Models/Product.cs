namespace WebAPI.Models;
public class Product // Objeto de produto aonde é associado a uma categoria.
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}
