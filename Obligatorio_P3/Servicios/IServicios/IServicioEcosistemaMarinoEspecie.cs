using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.IServicios
{
    public interface IServicioEcosistemaMarinoEspecie: IServicio<EcosistemaMarinoEspecie>
    {
        EcosistemaMarinoEspecie Add(int idEcosistema, int idEspecie);


    }
}
