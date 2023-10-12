using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.IServicios
{
    public interface IServicioEspecie: IServicio<EspecieDTO>
    {
        IEnumerable<EspecieDTO> GetAll();
        EspecieDTO GetById(int Id);
    }
}
