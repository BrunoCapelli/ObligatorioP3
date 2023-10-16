using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class Amenaza
    {
        public int AmenazaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EcosistemaMarinoId { get; set; }
        public int GradoPeligrosidad { get; set; }

        List<EspecieAmenaza> especieAmenazas = new List<EspecieAmenaza>();
        List<EcosistemaAmenaza> ecosistemaAmenazas = new List<EcosistemaAmenaza> { };

        public Amenaza() { }
        public Amenaza(AmenazaDTO amenazaDTO) {
            this.AmenazaId = amenazaDTO.AmenazaId;
            this.Nombre = amenazaDTO.Nombre;
            this.GradoPeligrosidad = amenazaDTO.GradoPeligrosidad;
            this.Descripcion = amenazaDTO.Descripcion;
        }
        
    }
}
