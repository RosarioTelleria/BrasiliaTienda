using BrasiliaTienda.Models;
using BrasiliaTiendaAccesoDato.Data.Repository;
using BrasiliaTiendaModelo;
using BrasiliaTiendaModelo.Models;
using BrasiliaTiendaModelo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BrasiliaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ArticulosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;

        }
        public IActionResult Index()
        {
           
         
            return View ();

        }
        [HttpGet]
        public ActionResult Create()
        {
            ArticuloVM artivm = new ArticuloVM()
            {
                Articulo = new Models.Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategoria()
            };
            return View(artivm);

        }

        #region 
        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties:"Categoria") });
        }

        #endregion
    }
}
