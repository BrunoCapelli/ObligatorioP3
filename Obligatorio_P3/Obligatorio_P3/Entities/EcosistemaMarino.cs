using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Entities
{
    public class EcosistemaMarino
    {
        public int EcosistemaMarinoId { get; set; }
        public string Nombre { get; set; }
        public UbiGeografica UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public List<Especie> Especies = new List<Especie>();
        public List<Amenaza> Amenazas = new List<Amenaza>();
        public EstadoConservacion EstadoConservacion { get; set; }
        public List<Pais> Paises = new List<Pais>();

        public EcosistemaMarino() { }

        public EcosistemaMarino(EcosistemaMarinoDTO ecosistemaMarinoDTO) {
            this.EcosistemaMarinoId = ecosistemaMarinoDTO.EcosistemaMarinoId;
            this.Nombre = ecosistemaMarinoDTO.Nombre;
            this.Area = ecosistemaMarinoDTO.Area;
            //aca hago una conversion de lo que viene en las listas?
        }

    }
}
