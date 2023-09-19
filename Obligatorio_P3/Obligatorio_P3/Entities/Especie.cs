using Domain.DTO;

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
        public List<Amenaza> Amenazas = new List<Amenaza>();
        public EstadoConservacion EstadoConservacion { get; set; }
        public List<EcosistemaMarino> EcosistemasHabitados = new List<EcosistemaMarino>();

        public Especie() { }
        public Especie(EspecieDTO especieDTO) {
            this.EspecieId = especieDTO.EspecieId;
            this.NombreCientifico = especieDTO.NombreCientifico;
            this.NombreVulgar = especieDTO.NombreVulgar;
            this.Descripcion = especieDTO.Descripcion;
            this.PesoMin = especieDTO.PesoMin;
            this.PesoMax = especieDTO .PesoMax;
            //aca hacer lo mismo que en el DTO pero al revez?
        }
    }
}
