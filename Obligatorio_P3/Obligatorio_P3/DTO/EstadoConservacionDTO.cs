using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO {
    public class EstadoConservacionDTO {
        public int EstadoConservacionId { get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }
        public EstadoConservacionDTO() { }
        public EstadoConservacionDTO(EstadoConservacion estadoConservacion) {
            this.EstadoConservacionId = estadoConservacion.EstadoConservacionId;
            this.Nombre = estadoConservacion.Nombre;
            this.Valor = estadoConservacion.Valor;
        }

    }
}
