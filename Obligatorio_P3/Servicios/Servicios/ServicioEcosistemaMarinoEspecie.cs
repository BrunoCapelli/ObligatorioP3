using Data_Access.IRepositorios;
using Domain.DTO;
using Domain.Entities;
using Domain.Exceptions;
using Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class ServicioEcosistemaMarinoEspecie : IServicioEcosistemaMarinoEspecie
    {
        private IRepositorioEcosistemaMarinoEspecie _repositorioEcosistemaMarinoEspecie;
        private IRepositorioEcosistemaMarino _repositorioEcosistemaMarino;
        private IRepositorioEspecie _repositorioEspecie;
        public ServicioEcosistemaMarinoEspecie(IRepositorioEcosistemaMarinoEspecie repositorioEcosistemaMarinoEspecie, IRepositorioEcosistemaMarino repositorioEcosistemaMarino, IRepositorioEspecie repositorioEspecie)
        {
            _repositorioEcosistemaMarinoEspecie = repositorioEcosistemaMarinoEspecie;
            _repositorioEcosistemaMarino = repositorioEcosistemaMarino;
            _repositorioEspecie = repositorioEspecie;
        }

        public EcosistemaMarinoEspecie Add(int ecosistemaId, int especieId)
        {
            if(ecosistemaId > 0 && especieId > 0)
            {
                EcosistemaMarino ecosistema = _repositorioEcosistemaMarino.GetById(ecosistemaId);
                Especie especie = _repositorioEspecie.GetById(especieId);
                if (_repositorioEcosistemaMarinoEspecie.GetByEcosistemaId(ecosistemaId).EcosistemaMarinoId!= 0 &&  _repositorioEcosistemaMarinoEspecie.GetByEspecieId(especieId).EspecieId != 0)
                {
                    throw new DatabaseException("La asociacion ya existe");
                }
                else
                {
                    EcosistemaMarinoEspecie newEme = new EcosistemaMarinoEspecie(ecosistema, especie);
                    _repositorioEcosistemaMarinoEspecie.Add(newEme);
                    _repositorioEcosistemaMarino.Save();

                    return newEme;
                }

            }
            else
            {

                throw new Exception("El ecosistema o especie ingresado no es valido");
            }
            
        }

        public EcosistemaMarinoEspecie Add(EcosistemaMarinoEspecie entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(EcosistemaMarinoEspecie entity)
        {
            throw new NotImplementedException();
        }

        public void Update(EcosistemaMarinoEspecie entity)
        {
            throw new NotImplementedException();
        }

        public bool isApto(int especieId, int ecosistemaId)
        {
            bool resultado = false;
            EcosistemaMarino eM = _repositorioEcosistemaMarinoEspecie.GetByEcosistemaId(ecosistemaId);
            Especie e = _repositorioEcosistemaMarinoEspecie.GetByEspecieId(especieId);

            // Chequeo que el estado de conservación del ecosistema no sea peor que el de la especie que se le está asociando
            if (eM.EstadoConservacion.ValorHasta < e.EstadoConservacion.ValorHasta)
            {
                return true;
            }

            // Falta para la parte de amenazas
            return resultado;
        }
    }
}
