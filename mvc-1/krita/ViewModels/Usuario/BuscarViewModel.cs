using System;
using Model = Shared.Models;

namespace krita.ViewModels.Usuario
{
    public class BuscarViewModel
    {
        public int? Id { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public int? Bloqueado { get; set; }
        public string BloqueadoFormatado { get; set; }
        public IEnumerable<Model.RespostaBusca> RespostaBusca { get; set; }
    }
}
