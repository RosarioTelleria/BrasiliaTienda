using BrasiliaTiendaAccesoDato.Data.Repository;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            return View();
        }

        #region 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });
        }

        #endregion
    }
}
