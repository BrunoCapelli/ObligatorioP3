using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Audit
    {
        public string Usuario { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdEntidad { get; set; }
        public string TipoEntidad { get; set; }
    }
}
