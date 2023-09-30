using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO
{
    public class PaisDTO
    {
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public IEnumerable<EcosistemaMarinoDTO> Ecosistemas = new List<EcosistemaMarinoDTO>();
        public PaisDTO() { }
        public PaisDTO(Pais pais) {
            this.PaisId = pais.PaisId;
            this.Codigo = pais.Codigo;
            this.Nombre = pais.Nombre;
        }

    }
}
