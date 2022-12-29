using BrasiliaTiendaModelo;
using BrasiliaTiendaModelo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasiliaTiendaAccesoDato.Data.Repository
{
    public interface IUsuariosRepository : IRepository<Usuarios>
    {
        

        void BloquearUsuarios (string IdUsuario);
        void DesbloquearUsuario(string IdUsuario);

    }
}
