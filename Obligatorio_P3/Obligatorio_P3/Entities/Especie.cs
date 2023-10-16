using Domain.DTO;
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

        /*public void Validate()
        {
            if(this.NombreCientifico == "")
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

        }*/
    }
}
