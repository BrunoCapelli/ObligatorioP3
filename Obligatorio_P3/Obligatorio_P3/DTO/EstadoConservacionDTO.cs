using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;

namespace Domain.DTO {
    public class EstadoConservacionDTO {
        public int EstadoConservacionId { get; set; }
        public string Nombre { get; set; }
        public int ValorDesde { get; set; }
        public int ValorHasta { get; set; }
        public EstadoConservacionDTO() { }
        public EstadoConservacionDTO(EstadoConservacion estadoConservacion) {
            this.EstadoConservacionId = estadoConservacion.EstadoConservacionId;
            this.Nombre = estadoConservacion.Nombre;
            this.ValorDesde = estadoConservacion.ValorDesde;
            this.ValorHasta = estadoConservacion.ValorHasta;

        }
        public EstadoConservacionDTO(int valor) 
        {
            if (valor > 100 && valor < 0)
            {
                throw new RangoException("Valor fuera de rango");
            }
            else
            {
                if (valor < 60)
                {
                    this.Nombre = "Malo";
                }
                if (valor >60 && valor < 70)
                {
                    this.Nombre = "Aceptable";
                }

                if(valor >= 70 && valor <= 95)
                {
                    this.Nombre = "Bueno";
                }

                if(valor > 95 && valor < 100)
                {
                    this.Nombre = "Optimo";
                }
            }
        }
    }
}
