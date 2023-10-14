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
                EcosistemaMarino ecosistema = _repositorioEcosistemaMarino.GetById(especieId);
                Especie especie = _repositorioEspecie.GetById(especieId);

                EcosistemaMarinoEspecie newEme = new EcosistemaMarinoEspecie(ecosistema, especie);

                _repositorioEcosistemaMarinoEspecie.Add(newEme);
                return newEme;
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
    }
}
