using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Domain.Entities
{
    public class UbiGeografica
    {
        public int UbiGeograficaId { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set;}
        public int GradoPeligro { get; set; }
        public UbiGeografica() { }
        public UbiGeografica(UbiGeograficaDTO ubiGeograficaDTO) {
            this.UbiGeograficaId = ubiGeograficaDTO.UbiGeograficaId;
            this.GradoPeligro = ubiGeograficaDTO.GradoPeligro;
            this.Longitud = ubiGeograficaDTO.Longitud;
            this.Latitud = ubiGeograficaDTO.Latitud;
        }
        public void Copy(UbiGeograficaDTO ubiGeograficaDTO) {
            this.Latitud = ubiGeograficaDTO.Latitud;
            this.Longitud = ubiGeograficaDTO.Longitud;
            this.GradoPeligro = ubiGeograficaDTO .GradoPeligro;
        }
    }
}
