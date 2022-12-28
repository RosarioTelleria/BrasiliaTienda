using BrasiliaTiendaAccesoDato.Data.Repository;
using BrasiliaTiendaModelo;
using BrasiliaTiendaModelo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasiliaTiendaAccesoDato.Data
{
    public class SlidersRepository : Repository<Slider>, ISlidersRepository
    {
        private readonly ApplicationDbContext _db;

        public SlidersRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Slider slider)
        {
            var objDesdeDb = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
            objDesdeDb.Estado = slider.Estado;
            objDesdeDb.Nombre = slider.Nombre;
            objDesdeDb.UrlImagen = slider.UrlImagen;
           
            _db.SaveChanges();
        }
    }
}
