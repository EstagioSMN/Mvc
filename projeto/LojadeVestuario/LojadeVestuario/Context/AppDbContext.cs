using LojadeVestuario.Models;
using Microsoft.EntityFrameworkCore;

namespace LojadeVestuario.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Mapeado a classe categoria em uma tabela categorias
        // A partir das <classes> sao criadas tabelas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Camisas> Camisas { get; set; }
    }
}
