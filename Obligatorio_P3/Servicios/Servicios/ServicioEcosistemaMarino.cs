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
        private IRepositorioEstadoConservacion _repoEstadoConservacion;

        public ServicioEcosistemaMarino(IRepositorioEcosistemaMarino repoEcosistemaMarino, IRepositorioEstadoConservacion repoEstadoConservacion) {
            _repoEcosistemaMarino = repoEcosistemaMarino;
            _repoEstadoConservacion = repoEstadoConservacion;
        }
        public EcosistemaMarinoDTO Add(EcosistemaMarinoDTO entity) {
            
            entity.Validate();
            //EcosistemaMarinoDTO eco = FindByName(entity.Nombre);
            
            if (entity != null) {

                int EstadoId = entity.EstadoConservacion.EstadoConservacionId;
                EstadoConservacion estado = _repoEstadoConservacion.GetEstado(EstadoId);

                EcosistemaMarino ecosistema = new EcosistemaMarino(entity, estado);

               

                EcosistemaMarino newEco = _repoEcosistemaMarino.Add(ecosistema);
               
                _repoEcosistemaMarino.Save();
                EcosistemaMarinoDTO newECODto = new EcosistemaMarinoDTO(newEco);
                return newECODto;

            } else {
                throw new Exception("El Ecosistema ingresado ya existe.");
            }
            

        }


        public void Remove(EcosistemaMarinoDTO entity) {
            //EcosistemaMarino ecoToRemove = new EcosistemaMarino(entity);
           // _repoEcosistemaMarino.Remove(ecoToRemove);
        }

        public void Update(EcosistemaMarinoDTO entity) {
            
        }

        public IEnumerable<EcosistemaMarinoDTO> GetAll()
        {
            List<EcosistemaMarinoDTO> ecosistemasDTO = new List<EcosistemaMarinoDTO>();
            IEnumerable<EcosistemaMarino> ecosistemas = _repoEcosistemaMarino.GetAll();
            foreach (EcosistemaMarino e in ecosistemas)
            {
                EcosistemaMarinoDTO ecosistemaDTO = new EcosistemaMarinoDTO(e);
                ecosistemasDTO.Add(ecosistemaDTO);
            }


            return ecosistemasDTO;
        }

        public EcosistemaMarinoDTO FindByName(string nombre) {
            EcosistemaMarino eco = _repoEcosistemaMarino.GetEcosistemaByName(nombre);
            EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(eco);

            return ecoDTO; 
        }

        public EcosistemaMarinoDTO GetById(int Id)
        {
            EcosistemaMarino eBuscada = _repoEcosistemaMarino.GetById(Id);
            EcosistemaMarinoDTO eDTO = new EcosistemaMarinoDTO(eBuscada);

            return eDTO;
        }
    }
}
