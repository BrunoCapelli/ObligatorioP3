using Data_Access.IRepositorios;
using Domain.DTO;
using Domain.Entities;
using Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servicios.Servicios
{
    public class ServicioEspecie: IServicioEspecie
    {
        private IRepositorioEspecie _repoEspecie;
        private IRepositorioEstadoConservacion _repoEstadoConservacion;
        private IRepositorioEcosistemaMarinoEspecie _repoEcosistemaMarinoEspecie;
        private IRepositorioEcosistemaMarino _repoEcosistemaMarino;
        public ServicioEspecie(IRepositorioEspecie repoEspecie, IRepositorioEstadoConservacion repoEstadoConservacion, IRepositorioEcosistemaMarinoEspecie repoEcosistemaMarinoEspecie,
            IRepositorioEcosistemaMarino repositorioEcosistemaMarino)
        {
            _repoEspecie = repoEspecie;
            _repoEstadoConservacion = repoEstadoConservacion;
            _repoEcosistemaMarinoEspecie = repoEcosistemaMarinoEspecie;
            _repoEcosistemaMarino = repositorioEcosistemaMarino;
        }

        public EspecieDTO Add(EspecieDTO especieDTO)
        {
            especieDTO.Validate();

            if(especieDTO != null)
            {
                int EstadoId = especieDTO.EstadoConservacion.EstadoConservacionId;
                EstadoConservacion estado = _repoEstadoConservacion.GetEstado(EstadoId);

                Especie newEspecie = new Especie(especieDTO, estado);

                Especie especieAdded = _repoEspecie.Add(newEspecie);
                _repoEspecie.Save();

                EspecieDTO especieDTO1 = new EspecieDTO(especieAdded);
                return especieDTO1;
            }
            else
            {
                throw new Exception("La especie es invalida");
            }

        }

        public IEnumerable<EspecieDTO> GetAll()
        {
            List<EspecieDTO> especiesDTO = new List<EspecieDTO>();
            IEnumerable<Especie> especies = _repoEspecie.GetAllEspecies();
            foreach (Especie e in especies)
            {
                EspecieDTO especieDTO = new EspecieDTO(e);
                especiesDTO.Add(especieDTO);
            }
            return especiesDTO;

        }

        public void Update(EspecieDTO entity)
        {
            throw new NotImplementedException();
        }

        public EspecieDTO GetById(int Id)
        {
            Especie eBuscada = _repoEspecie.GetById(Id);
            EspecieDTO eDTO = new EspecieDTO(eBuscada);

            return eDTO;
        }

        public IEnumerable<EspecieDTO> FiltrarPorNombreCientifico(string nombre)
        {
            IEnumerable<EspecieDTO> especies = GetAll();
            List<EspecieDTO> especieFiltradas = new List<EspecieDTO>();
            foreach (EspecieDTO especie in especies)
            {
                if (nombre != "" && especie.NombreCientifico.Contains(nombre) )
                {
                    especieFiltradas.Add(especie);
                }
            }
            return especieFiltradas;
        }

        
        public IEnumerable<EspecieDTO> FiltrarPorGradoDeConservacion(int estadoId)
        {
            IEnumerable<Especie> especies = _repoEspecie.GetAllEspecies();
            List<Especie> especieFiltradas = new List<Especie>();

            foreach (Especie especie in especies)
            {
                if (estadoId!=0 && especie.EstadoConservacion.EstadoConservacionId == estadoId)
                {
                    especieFiltradas.Add(especie);
                }
            }

            List<EspecieDTO> especiesDTO = new List<EspecieDTO>();
            foreach (Especie e in especieFiltradas)
            {
                EspecieDTO especieDTO = new EspecieDTO(e);
                especiesDTO.Add(especieDTO);
            }

            return especiesDTO;
        }

        public IEnumerable<EspecieDTO> FiltrarPorPeso(int pesoDesde, int pesoHasta)
        {
            IEnumerable<Especie> especies = _repoEspecie.GetAll();
            List<Especie> especieFiltradas = new List<Especie>();

            foreach (Especie especie in especies)
            {
                if (especie.PesoMin >= pesoDesde && especie.PesoMax <= pesoHasta)
                {
                    especieFiltradas.Add(especie);
                }
            }

            List<EspecieDTO> especiesDTO = new List<EspecieDTO>();
            foreach (Especie e in especieFiltradas)
            {
                EspecieDTO especieDTO = new EspecieDTO(e);
                especiesDTO.Add(especieDTO);
            }

            return especiesDTO;
        }

        public IEnumerable<EspecieDTO> FiltrarPorEcosistema(int EcosistemaId)
        {

            IEnumerable<EcosistemaMarinoEspecie> Ecosistemas = _repoEcosistemaMarinoEspecie.GetAll();
             List<EspecieDTO> especieFiltradas = new List<EspecieDTO>();
             foreach (EcosistemaMarinoEspecie eco in Ecosistemas)
             {
                if(eco.EcosistemaMarinoId == EcosistemaId)
                {
                    EspecieDTO especieDto = new EspecieDTO(eco.Especie);
                    especieFiltradas.Add(especieDto);
                }

             }
             return especieFiltradas;
        }
        public IEnumerable<EcosistemaMarinoDTO> FiltrarPorEspecieQueNoHabita(int EspecieId)
        {

            IEnumerable<EcosistemaMarinoEspecie> EcosistemaEspecie = _repoEcosistemaMarinoEspecie.GetAll();
            IEnumerable<EcosistemaMarino> Ecosistemas = _repoEcosistemaMarino.GetAllEcosistemas();
            List<EcosistemaMarino> EcosistemasNoHabitados = new List<EcosistemaMarino>();
            //List<EspecieDTO> especieFiltradas = new List<EspecieDTO>();
            List<EcosistemaMarinoDTO> EcosistemasFiltrados = new List<EcosistemaMarinoDTO>();


            foreach (EcosistemaMarinoEspecie eco in EcosistemaEspecie)
            {
                if (eco.EspecieId != EspecieId)
                {
                    EcosistemasNoHabitados.Add(eco.EcosistemaMarino);
                }

            }

            foreach(EcosistemaMarino eco in EcosistemasNoHabitados)
            {
                foreach(EcosistemaMarino ecosistema in Ecosistemas)
                {
                    if(eco.EcosistemaMarinoId == ecosistema.EcosistemaMarinoId)
                    {
                        EcosistemaMarinoDTO ecoDTO = new EcosistemaMarinoDTO(eco);
                        EcosistemasFiltrados.Add(ecoDTO);
                    }

                }
            }


            return EcosistemasFiltrados;
        }

        public void Remove(int id) {
            Especie esp = _repoEspecie.GetById(id);
            _repoEspecie.Remove(esp);
            _repoEspecie.Save();
        }
    }
}
