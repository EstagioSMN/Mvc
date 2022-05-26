using LojadeVestuario.Context;
using LojadeVestuario.Models;
using LojadeVestuario.Repositories.Interfaces;

namespace LojadeVestuario.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
