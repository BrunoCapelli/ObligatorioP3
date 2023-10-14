﻿using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.IServicios
{
    public interface IServicioEcosistemaMarino:IServicio<EcosistemaMarinoDTO>
    {
        IEnumerable<EcosistemaMarinoDTO> GetAll();

        void RemoveById(int id);
        
    }
}
