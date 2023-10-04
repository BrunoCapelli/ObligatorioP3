using Data_Access.IRepositorios;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private MiContexto Context { get; set; }

        public RepositorioUsuario(MiContexto _context)
        {
            Context = _context;
        }

        public Usuario Add(Usuario entity)
        {
            Context.Set<Usuario>().Add(entity);
            return entity;
        }

        public void Remove(Usuario entity)
        {
            Context.Set<Usuario>().Remove(entity);
        }

        public void Save()
        {
           Context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public Usuario GetUsuarioByAlias(string userAlias)
        {
            Usuario user = Context.Usuarios.FirstOrDefault(u => u.Alias == userAlias);

            return user;
        }
    }
}
