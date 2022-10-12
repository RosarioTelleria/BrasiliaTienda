using BrasiliaTienda.Models;
using BrasiliaTiendaAccesoDato.Data.Repository;
using BrasiliaTiendaModelo;
using BrasiliaTiendaModelo.Models;
using BrasiliaTiendaModelo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Hosting.Internal;

namespace BrasiliaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ArticulosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloVM artiVM)
        {
            if(ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if(artiVM.Articulo.Id == 0)
                {
                    string nombreArchivo=Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"Imagenes\Articulos");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension),FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);

                    }
                    artiVM.Articulo.UrlImagen = @"Imagenes\Articulos" + nombreArchivo + extension;
                    artiVM.Articulo.FechaCreacion = DateTime.Now.ToString();
                    _contenedorTrabajo.Articulo.Add(artiVM.Articulo);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            artiVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategoria();
            return View(artiVM);
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
