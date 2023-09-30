using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Entities
{
    public class Amenaza
    {
        public int AmenazaId { get; set; }
        public string Nombre { get; set; }
        public int EcosistemaMarinoId { get; set; }
        public int GradoPeligrosidad { get; set; }

        public Amenaza() { }
        public Amenaza(AmenazaDTO amenazaDTO) {
            this.AmenazaId = amenazaDTO.AmenazaId;
            this.Nombre = amenazaDTO.Nombre;
            this.GradoPeligrosidad = amenazaDTO.GradoPeligrosidad;
        }
        public void Copy(AmenazaDTO amenazaDTO) {
            this.Nombre = amenazaDTO.Nombre;
            this.GradoPeligrosidad = amenazaDTO .GradoPeligrosidad;
        }
    }
}
