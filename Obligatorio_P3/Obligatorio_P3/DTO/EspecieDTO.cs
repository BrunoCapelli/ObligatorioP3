using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO {
    public class EspecieDTO {
        public int EspecieId { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion { get; set; }
        public double PesoMin { get; set; }
        public double PesoMax { get; set; }
        public List<AmenazaDTO> Amenazas { get; set; }
        public EstadoConservacionDTO EstadoConservacion { get; set; }
        public List<EcosistemaMarinoDTO> EcosistemasHabitados { get; set; }
        public EspecieDTO() { }
        public EspecieDTO(Especie especie) {
            
            this.EspecieId = especie.EspecieId;
            this.NombreCientifico = especie.NombreCientifico;
            this.NombreVulgar = especie.NombreVulgar;
            this.Descripcion = especie.Descripcion;
            this.PesoMin = especie.PesoMin;
            this.PesoMax = especie.PesoMax;



        }
    }
}
