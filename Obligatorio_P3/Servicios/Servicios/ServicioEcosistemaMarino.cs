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
    public class ServicioEcosistemaMarino : IServicioEcosistemaMarino {

        private IRepositorioEcosistemaMarino _repoEcosistemaMarino;
        public ServicioEcosistemaMarino(IRepositorioEcosistemaMarino repoEcosistemaMarino) {
            _repoEcosistemaMarino = repoEcosistemaMarino;
        }
        public EcosistemaMarinoDTO Add(EcosistemaMarinoDTO entity) {
            
            entity.Validate();
            EcosistemaMarinoDTO eco = FindByName(entity.Nombre);
            if (eco == null) {
                EcosistemaMarino ecosistema = new EcosistemaMarino(entity);
                EcosistemaMarino newEco = _repoEcosistemaMarino.Add(ecosistema);
                _repoEcosistemaMarino.Save();

            } else {
                throw new Exception("El Ecosistema ingresado ya existe.");
            }

        }

        public void Remove(EcosistemaMarinoDTO entity) {
            throw new NotImplementedException();
        }

        public void Update(EcosistemaMarinoDTO entity) {
            throw new NotImplementedException();
        }

        public EcosistemaMarinoDTO FindByName(string nombre) {
            EcosistemaMarino eco = _repoEcosistemaMarino.GetEcosistemaByName(nombre);
            EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(eco);

            
        }
    }
}
