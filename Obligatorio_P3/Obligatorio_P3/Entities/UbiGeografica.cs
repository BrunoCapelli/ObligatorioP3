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
        public double Latitud { get; private set; }
        public double Longitud { get; private set;}
        public int GradoPeligro { get; private set; }
        public UbiGeografica() { }
        public UbiGeografica(double latitud, double longitud, int gradoPeligro) {
            this.GradoPeligro = gradoPeligro;
            this.Longitud = longitud;
            this.Latitud = latitud;
        }
       
    }
}
