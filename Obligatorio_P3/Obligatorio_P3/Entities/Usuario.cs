using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }

    }
}
