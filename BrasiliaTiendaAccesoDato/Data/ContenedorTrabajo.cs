using BrasiliaTiendaAccesoDato.Data.Repository;
using BrasiliaTiendaModelo;
using BrasiliaTiendaModelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasiliaTiendaAccesoDato.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
            Articulo = new ArticuloRepository(_db);
            Slider = new SlidersRepository(_db);
            usuarios = new UsuarioRepository(_db);


        }

        public ICategoriaRepository Categoria { get; private set; }
        public IArticuloRepository Articulo { get; private set; }

        public ISlidersRepository Slider { get; private set; }
        public IUsuariosRepository usuarios { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
