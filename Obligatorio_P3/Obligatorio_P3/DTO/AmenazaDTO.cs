using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO {
    public class AmenazaDTO {
        public int AmenazaId { get; set; }
        public string Nombre { get; set; }

        public int GradoPeligrosidad { get; set; }

        public AmenazaDTO() { }

        public AmenazaDTO(Amenaza amenaza) {
            this.AmenazaId = amenaza.AmenazaId;
            this.Nombre = amenaza.Nombre;
            this.GradoPeligrosidad = amenaza.GradoPeligrosidad;
        }
    }
}
