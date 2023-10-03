using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Entities
{
    public class EstadoConservacion
    {
        public int EstadoConservacionId { get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }
        public EstadoConservacion() { }
        public EstadoConservacion(EstadoConservacionDTO estadoConservacionDTO) {
            this.EstadoConservacionId = estadoConservacionDTO.EstadoConservacionId;
            this.Nombre = estadoConservacionDTO.Nombre;
            this.Valor = estadoConservacionDTO.Valor;
        }
        public void Copy(EstadoConservacionDTO estadoConservacionDTO) {
            this.Nombre = estadoConservacionDTO.Nombre;
            this.Valor = estadoConservacionDTO .Valor;
        }
    }
}
