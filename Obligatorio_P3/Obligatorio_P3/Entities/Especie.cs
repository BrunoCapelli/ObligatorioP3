namespace Domain.Entities
{
    public class Especie
    {
        public string NombreCientifico { get; set; }
        public string NombreVulgar { get; set; }
        public string Descripcion {  get; set; }
        public double PesoMin { get; set; }
        public double PesoMax { get; set; }
        public List<Amenaza> Amenazas { get; set; } 
        public EstadoConservacion EstadoConservacion { get; set; }
        public List<EcosistemaMarino> EcosistemasHabitados { get; set; }
    }
}
