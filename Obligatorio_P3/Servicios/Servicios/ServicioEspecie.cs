using Data_Access.IRepositorios;
using Domain.DTO;
using Domain.Entities;
using Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class ServicioEspecie: IServicioEspecie
    {
        private IRepositorioEspecie _repoEspecie;
        public ServicioEspecie(IRepositorioEspecie repoEspecie)
        {
            _repoEspecie = repoEspecie;
        }

        public EspecieDTO Add(EspecieDTO especieDTO)
        {
            Especie especie = new Especie(especieDTO);
            if(especie != null)
            {
                _repoEspecie.Add(especie);
                _repoEspecie.Save();
            }

            return especieDTO;
        }

        public IEnumerable<EspecieDTO> GetAll()
        {
            List<EspecieDTO> especiesDTO = new List<EspecieDTO>();
            IEnumerable<Especie> especies = _repoEspecie.GetAll();
            foreach (Especie e in especies)
            {
                EspecieDTO especieDTO = new EspecieDTO(e);
                especiesDTO.Add(especieDTO);
            }
            return especiesDTO;

        }

        public void Remove(EspecieDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EspecieDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
