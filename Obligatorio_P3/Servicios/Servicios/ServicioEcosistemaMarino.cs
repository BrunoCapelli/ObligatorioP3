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
        private IRepositorioPais _repoPais;

        public ServicioEcosistemaMarino(IRepositorioEcosistemaMarino repoEcosistemaMarino, IRepositorioEstadoConservacion repoEstadoConservacion,IRepositorioPais repoPais) {
            _repoEcosistemaMarino = repoEcosistemaMarino;
            _repoEstadoConservacion = repoEstadoConservacion;
            _repoPais = repoPais;
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
            List<EcosistemaMarinoDTO> res = new List<EcosistemaMarinoDTO>();
            IEnumerable<EcosistemaMarino> Ecosistemas = _repoEcosistemaMarino.GetAllEcosistemas();
            foreach(EcosistemaMarino e in  Ecosistemas) {
                EcosistemaMarinoDTO ecosistemaMarinoDTO = new EcosistemaMarinoDTO(e);
                Pais pais = _repoPais.GetPais(e.PaisId);
                ecosistemaMarinoDTO.PaisNombre = pais.Nombre;
                //Aca traigo nombre del pais
                res.Add(ecosistemaMarinoDTO);
            }
            
            return res;
        }

        public EcosistemaMarinoDTO FindByName(string nombre) {
            EcosistemaMarino eco = _repoEcosistemaMarino.GetEcosistemaByName(nombre);
            EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(eco);
            Pais pais = _repoPais.GetPais(eco.PaisId);
            ecoDTO.PaisNombre = pais.Nombre;
            //Aca traigo nombre del pais
            return ecoDTO; 
        }

        public EcosistemaMarinoDTO GetById(int Id)
        {
            EcosistemaMarino eBuscada = _repoEcosistemaMarino.GetById(Id);
            EcosistemaMarinoDTO eDTO = new EcosistemaMarinoDTO(eBuscada);

            return eDTO;
        }

        public void Remove(int id) {
            EcosistemaMarino eco = _repoEcosistemaMarino.GetById(id);
            _repoEcosistemaMarino.Remove(eco);
            _repoEcosistemaMarino.Save();
        }
    }
}
