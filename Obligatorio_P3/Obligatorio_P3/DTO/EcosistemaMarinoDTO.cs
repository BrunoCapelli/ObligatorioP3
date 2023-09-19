using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO {
    public class EcosistemaMarinoDTO {
        public int EcosistemaMarinoId { get; set; }
        public string Nombre { get; set; }
        public UbiGeografica UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public List<EspecieDTO> Especies = new List<EspecieDTO>();
        public List<AmenazaDTO> Amenazas = new List<AmenazaDTO>();
        public EstadoConservacionDTO EstadoConservacion { get; set; }
        public List<PaisDTO> Paises = new List<PaisDTO>();
    }
}
