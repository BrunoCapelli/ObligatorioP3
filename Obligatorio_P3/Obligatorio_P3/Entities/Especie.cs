﻿using Domain.DTO;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class Especie
    {
        public int EspecieId { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion {  get; set; }
        public double PesoMin { get; set; }
        public double PesoMax { get; set; }
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
            this.EstadoConservacion = EstadoConservacion;
            
        }

    }
}
