using Data_Access.IRepositorios;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repositorios
{
    public class RepositorioEcosistemaMarinoEspecie : Repositorio<RepositorioEcosistemaMarinoEspecie>, IRepositorioEcosistemaMarinoEspecie
    {
        public RepositorioEcosistemaMarinoEspecie(MiContexto contexto)
        {
            Context = contexto;
        }

        public EcosistemaMarinoEspecie Add(EcosistemaMarinoEspecie entity)
        {
             Context.Set<EcosistemaMarinoEspecie>().Add(entity);
            return entity;
        }


        public void Remove(EcosistemaMarinoEspecie entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EcosistemaMarinoEspecie entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<EcosistemaMarinoEspecie> IRepositorio<EcosistemaMarinoEspecie>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
