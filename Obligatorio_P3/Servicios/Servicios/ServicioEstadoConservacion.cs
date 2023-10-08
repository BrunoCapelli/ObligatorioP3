using Data_Access.IRepositorios;
using Domain.DTO;
using Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class ServicioEstadoConservacion : IServicioEstadoConservacion
    {
        private IRepositorioEstadoConservacion _repoEstadoConservacion;
        public ServicioEstadoConservacion(IRepositorioEstadoConservacion repoEstadoConservacion) 
        {
            _repoEstadoConservacion = repoEstadoConservacion;
        }
    }
}
