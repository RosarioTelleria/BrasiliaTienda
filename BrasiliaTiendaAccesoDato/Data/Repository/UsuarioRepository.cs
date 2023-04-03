using BrasiliaTiendaModelo;
using BrasiliaTiendaModelo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasiliaTiendaAccesoDato.Data.Repository
{
    public class UsuarioRepository : Repository<Usuarios>, IUsuariosRepository
    {

        private readonly ApplicationDbContext _db;

        public  UsuarioRepository (ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void BloquearUsuarios(string idUsuario)
        {
            var usuarioDesdedb = _db.Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario);
            usuarioDesdedb.lockoutEnd = DateTime.Now.AddYears(100);
            _db.SaveChanges();

        }

        public void DesbloquearUsuario(string idUsuario)
        {
            var usuarioDesdedb = _db.Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario);
            usuarioDesdedb.lockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
