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
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        private MiContexto Context { get; set; }

        public RepositorioUsuario(MiContexto _context)
        {
            Context = _context;
        }

       
        public Usuario GetUsuarioByAlias(string userAlias)
        {
            Usuario user = Context.Usuarios.FirstOrDefault(u => u.Alias == userAlias);

            return user;
        }

        public Usuario GetUsuarioById(int id)
        {
            Usuario user = Context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);

            return user;
        }
    }
}
