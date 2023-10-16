using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public List<EcosistemaMarino> ecosistemaMarinos = new List<EcosistemaMarino>();


        public Pais() { } 

        public Pais(PaisDTO paisDTO) {
            this.PaisId = paisDTO.PaisId;
            this.Nombre = paisDTO.Nombre;
            this.Codigo = paisDTO.Codigo;
        }

    }
}
