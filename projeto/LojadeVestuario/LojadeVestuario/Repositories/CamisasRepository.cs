using LojadeVestuario.Context;
using LojadeVestuario.Models;
using LojadeVestuario.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojadeVestuario.Repositories
{
    public class CamisasRepository : ICamisasRepository
    {
        private readonly AppDbContext _context;

        public CamisasRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Camisas> Camisas => _context.Camisas.Include(c => c.Categoria);

        public IEnumerable<Camisas> Camisasmaisvendida => _context.Camisas.
                                                          Where(l => l.IsCamisamaisVendida)
                                                         .Include(c => c.Categoria);

        public Camisas GetCamisasById(int CamisasId)
        {
            return _context.Camisas.FirstOrDefault(l => l.CamisasId == CamisasId);
        }
    }
}
