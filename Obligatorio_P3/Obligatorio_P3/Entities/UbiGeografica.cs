using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UbiGeografica
    {
        public int UbiGeograficaId { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set;}
        public int GradoPeligro { get; set; }
    }
}
