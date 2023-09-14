using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EcosistemaMarino
    {
        public string Nombre { get; set; }
        public UbiGeografica UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public List<Especie> Especies = new List<Especie>();
        public List<Amenaza> Amenazas = new List<Amenaza>();
        public EstadoConservacion EstadoConservacion { get; set; }
        public List<Pais> Paises = new List<Pais>();

    }
}
