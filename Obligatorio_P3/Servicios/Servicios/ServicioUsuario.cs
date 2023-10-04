using Data_Access.IRepositorios;
using Domain.DTO;
using Domain.Entities;
using Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios
{
    public class ServicioUsuario: IServicioUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        public ServicioUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public Usuario Find(UsuarioDTO user)
        {

            Usuario aUser = new Usuario() { Alias = user.Alias, Password = user.Password };

            if(aUser != null)
            {
                aUser = _repoUsuario.GetUsuarioByAlias(aUser.Alias);
            }
            return aUser;
        }
    }
}
