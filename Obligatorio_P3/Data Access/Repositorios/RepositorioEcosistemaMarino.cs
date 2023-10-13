﻿using Data_Access.IRepositorios;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repositorios
{
    public class RepositorioEcosistemaMarino : Repositorio<EcosistemaMarino>, IRepositorioEcosistemaMarino {

        public RepositorioEcosistemaMarino(MiContexto context) {
            Context = context;
        }
        public EcosistemaMarino GetEcosistemaByName(string nombre) {
            EcosistemaMarino eco = Context.Ecosistemas.FirstOrDefault(e => e.Nombre == nombre);

            return eco;
        }

        public IEnumerable<EcosistemaMarino > GetAllEcosistemas() {
            return Context.Set<EcosistemaMarino>().Include(em => em.EstadoConservacion).ToList();
        }
    }
}
