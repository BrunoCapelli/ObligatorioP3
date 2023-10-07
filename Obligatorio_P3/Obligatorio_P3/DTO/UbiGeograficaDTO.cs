using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTO {
    public class UbiGeograficaDTO {
        public int UbiGeograficaId { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int GradoPeligro { get; set; }
        public UbiGeograficaDTO() { }
        public UbiGeograficaDTO(double latitud, double longitud) 
        {
            this.Latitud = latitud;
            this.Longitud = longitud;   
        }
        public UbiGeograficaDTO(UbiGeografica ubiGeografica) {
            this.UbiGeograficaId = ubiGeografica.UbiGeograficaId;
            this.Latitud = ubiGeografica.Latitud;  
            this.Longitud = ubiGeografica.Longitud;
            this.GradoPeligro = ubiGeografica.GradoPeligro;
        }
    }
}
