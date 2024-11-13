using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RH360.Data.DTO;
using RH360.Domain.Entities;

namespace RH360.Data.Interfaces
{
    public interface IUsuario
    {
        void AddUser(Usuario user); 
        void UpdateUser(Usuario user);
        Usuario GetUsuarioById(int id);
        void DeleteUser(int id);
        IEnumerable<Usuario> GetUsuarios();
    }
}
