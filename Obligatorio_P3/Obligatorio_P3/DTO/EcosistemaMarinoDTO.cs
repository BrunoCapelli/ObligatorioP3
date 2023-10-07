﻿using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO {
    public class EcosistemaMarinoDTO:IValidate {
        public int EcosistemaMarinoId { get; set; }
        public string Nombre { get; set; }
        public UbiGeograficaDTO UbicacionGeografica { get; set; }
        public double Area { get; set; }
        public List<EspecieDTO> Especies = new List<EspecieDTO>();
        public List<AmenazaDTO> Amenazas = new List<AmenazaDTO>();
        public EstadoConservacionDTO EstadoConservacion { get; set; }
        public int PaisId { get; set; }

        public EcosistemaMarinoDTO() { }

        public EcosistemaMarinoDTO(EcosistemaMarino eco) {
            this.EcosistemaMarinoId = eco.EcosistemaMarinoId;
            this.Nombre = eco.Nombre;
            this.Area = eco.Area;
            this.UbicacionGeografica = new UbiGeograficaDTO(eco.UbicacionGeografica);
            //llamar al validate de UbiGeograficaDTO
            this.PaisId = eco.PaisId;
            this.EstadoConservacion = new EstadoConservacionDTO(eco.EstadoConservacion);
            //llamar al validate de EstadoConservacionDTO
        }

        public EcosistemaMarinoDTO(string Nombre, UbiGeograficaDTO UbicacionGeografica, EstadoConservacionDTO estadoConservacion, int PaisId) {
            //this.EcosistemaMarinoId = EcosistemaMarinoId;
            this.Nombre = Nombre;
            this.UbicacionGeografica = UbicacionGeografica;
            this.EstadoConservacion = estadoConservacion;
            this.PaisId = PaisId;
        }

        public void Validate() {
            if (this.Nombre.Length < 2 || this.Nombre.Length> 50) {
                throw new NombreLargoException("El largo del nombre debe estar entre 2 y 50 caracteres");
            }
            if (this.Area <= 0) {
                throw new MagnitudException("El area debe ser positiva");
            }

        }
    }
}
