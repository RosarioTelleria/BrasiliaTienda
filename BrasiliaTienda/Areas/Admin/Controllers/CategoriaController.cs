﻿using BrasiliaTiendaAccesoDato.Data;
using BrasiliaTiendaAccesoDato.Data.Repository;
using BrasiliaTiendaModelo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BrasiliaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public CategoriaController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //listar en la regilla todos los usuarios ecepto el mio
            var claimIdentity = (ClaimIdentity)this.User.Identity;
            var usuarioActual = ClaimIdentity.findfirst(ClaimTypes.NameIdentifier);
            return Json(new { });//View(_contenedorTrabajo.usuarios.GetAll(u=>u.IdUsuario != usuarioActual.Value));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid){
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if(categoria == null){
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        #region 
        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);
            if (objFromDb == null){
                return Json(new { success = false, message = "Error borrando categoria" });
            }
            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();

            return Json(new { success = true, message = "Categoria borrada correctamente" });
        }
        #endregion
    }
}

namespace BrasiliaTienda
{
    class ClaimIdentity
    {
        internal static object findfirst(string nameIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}