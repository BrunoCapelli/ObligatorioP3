﻿using Data_Access.IRepositorios;
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
        private IRepositorioEstadoConservacion _repoEstadoConservacion;
        public ServicioEspecie(IRepositorioEspecie repoEspecie, IRepositorioEstadoConservacion repoEstadoConservacion)
        {
            _repoEspecie = repoEspecie;
            _repoEstadoConservacion = repoEstadoConservacion;
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
