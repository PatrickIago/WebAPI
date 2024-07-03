using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
namespace WebAPI.Data;
public class AppDbContext : DbContext // Responsavel pela minha conexão com o banco de dados.
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public  DbSet<Category> Categories { get; set; }
}
