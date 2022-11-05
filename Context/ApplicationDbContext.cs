using LancheBom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LancheBom.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base (options)
        {
            
        }
    }
}