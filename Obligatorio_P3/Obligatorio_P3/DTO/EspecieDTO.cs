﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Domain.DTO {
    public class EspecieDTO {
        public int EspecieId { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion { get; set; }
        public double PesoMin { get; set; }
        public double PesoMax { get; set; }
        public IFormFile Imagen { get; set; }
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

        public EspecieDTO(string NombreCientifico, string NombreVulgar, string Descripcion, double PesoMin, double PesoMax, EstadoConservacionDTO EstadoConservacion /**/ )
        {
            this.NombreCientifico = NombreCientifico;
            this.NombreVulgar= NombreVulgar;
            this.Descripcion = Descripcion;
            this.PesoMin = PesoMin;
            this.PesoMax = PesoMax;
            this.EstadoConservacion = EstadoConservacion;
        }

        public void Validate()
        {
            if (this.NombreCientifico == "")
            {
                throw new StringException("El nombre cientifico no puede ser vacio");
            }
            if (this.NombreVulgar == "")
            {
                throw new StringException("El nombre vulgar no puede ser vacio");
            }

            if (NombreCientifico.Length < 2 || NombreCientifico.Length > 50)
            {
                throw new NombreLargoException("El nombre cientifico debe contener entre 50 y 500 caracteres");
            }
            if (NombreCientifico.Length < 2 || NombreCientifico.Length > 50)
            {
                throw new NombreLargoException("El nombre vulgar debe contener entre 50 y 500 caracteres");
            }

            if (Descripcion == "")
            {
                throw new StringException("La descripcion no puede ser vacio");
            }
            if (Descripcion.Length < 50 || Descripcion.Length > 500)
            {
                throw new NombreLargoException("La descripcion debe contener entre 50 y 500 caracteres");
            }

            if (PesoMin <= 0)
            {
                throw new StringException("El peso debes ser positivo");
            }
            if (PesoMax <= 0)
            {
                throw new StringException("El peso debes ser positivo");
            }
            if (PesoMax < PesoMin)
            {
                throw new RangoException("El peso maximo debe ser mayor que el peso minimo");
            }

        }
    }
}
