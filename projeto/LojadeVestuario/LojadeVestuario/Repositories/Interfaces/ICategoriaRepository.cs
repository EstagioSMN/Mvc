using LojadeVestuario.Models;

namespace LojadeVestuario.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
