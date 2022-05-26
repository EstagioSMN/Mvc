using LojadeVestuario.Models;

namespace LojadeVestuario.Repositories.Interfaces
{
    public interface ICamisasRepository
    {
        IEnumerable<Camisas> Camisas { get; }
        IEnumerable<Camisas> Camisasmaisvendida { get; }
        Camisas GetCamisasById(int CamisasId);
    }
}
