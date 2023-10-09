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

            } else {
                throw new Exception("El Ecosistema ingresado ya existe.");
            }
            return entity;

        }


        public void Remove(EcosistemaMarinoDTO entity) {
            //EcosistemaMarino ecoToRemove = new EcosistemaMarino(entity);
           // _repoEcosistemaMarino.Remove(ecoToRemove);
        }

        public void Update(EcosistemaMarinoDTO entity) {
            
        }

        public IEnumerable<EcosistemaMarino> GetAll()
        {
            return _repoEcosistemaMarino.GetAll();
        }

        public EcosistemaMarinoDTO FindByName(string nombre) {
            EcosistemaMarino eco = _repoEcosistemaMarino.GetEcosistemaByName(nombre);
            EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(eco);

            return ecoDTO; 
        }
    }
}
