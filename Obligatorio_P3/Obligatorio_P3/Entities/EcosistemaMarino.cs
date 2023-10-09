using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class EcosistemaMarino//:IValidate
    {
        public int EcosistemaMarinoId { get; set; }
        public string Nombre { get; set; }
        public UbiGeografica UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public List<Amenaza> Amenazas = new List<Amenaza>();
        public EstadoConservacion EstadoConservacion { get; set; }
        public int PaisId { get; set; }
        public int? EspecieId { get; set; }
        public List<Especie> Especies = new List<Especie>();

        public EcosistemaMarino() { }
        
        public EcosistemaMarino(EcosistemaMarinoDTO ecosistemaMarinoDTO,EstadoConservacion estado) {
            this.EcosistemaMarinoId = ecosistemaMarinoDTO.EcosistemaMarinoId;
            this.Nombre = ecosistemaMarinoDTO.Nombre;
            this.Area = ecosistemaMarinoDTO.Area;
            this.UbicacionGeografica = ecosistemaMarinoDTO.UbicacionGeografica;
            this.PaisId = ecosistemaMarinoDTO.PaisId;
            this.EstadoConservacion = estado;


        }


    }
}
