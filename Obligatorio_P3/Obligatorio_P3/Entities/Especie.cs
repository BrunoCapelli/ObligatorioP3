﻿using Domain.DTO;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Especie : IValidable
    {
        public int EspecieId { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion {  get; set; }
        public double PesoMin { get; set; }
        public double PesoMax { get; set; }
        public int NombreMin { get; set; }
        public int NombreMax { get; set; }
        public int DescripcionMin { get; set; }
        public int DescripcionMax { get; set; }
        public List<EspecieAmenaza> EspecieAmenazas = new List<EspecieAmenaza>();
        public EstadoConservacion EstadoConservacion { get; set; }
        public int? EcosistemaMarinoId  { get; set; }
        public List<EcosistemaMarino> EcosistemasHabitados = new List<EcosistemaMarino>();
        

        public Especie() { }
        public Especie(EspecieDTO especieDTO, EstadoConservacion estado) {
            this.EspecieId = especieDTO.EspecieId;
            this.NombreCientifico = especieDTO.NombreCientifico;
            this.NombreVulgar = especieDTO.NombreVulgar;
            this.Descripcion = especieDTO.Descripcion;
            this.PesoMin = especieDTO.PesoMin;
            this.PesoMax = especieDTO .PesoMax;
            this.EstadoConservacion = estado;
            
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

            if (NombreCientifico.Length < NombreMin || NombreCientifico.Length > NombreMax)
            {
                throw new NombreLargoException("El nombre cientifico debe contener entre 50 y 500 caracteres");
            }
            if (NombreCientifico.Length < NombreMin || NombreCientifico.Length > NombreMax)
            {
                throw new NombreLargoException("El nombre vulgar debe contener entre 50 y 500 caracteres");
            }

            if (Descripcion == "")
            {
                throw new StringException("La descripcion no puede ser vacio");
            }
            if (Descripcion.Length < DescripcionMin || Descripcion.Length > DescripcionMax)
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
