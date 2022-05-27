using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class RespostaBusca
    {
        public int? Id { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public int? Bloqueado { get; set; }
        public DateTime? DataBloqueio { get; set; }
    }
}