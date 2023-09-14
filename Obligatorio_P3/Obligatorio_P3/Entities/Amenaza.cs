using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Amenaza
    {
        public int AmenazaId { get; set; }
        public string Nombre { get; set; }

        public int GradoPeligrosidad { get; set; }
    }
}
