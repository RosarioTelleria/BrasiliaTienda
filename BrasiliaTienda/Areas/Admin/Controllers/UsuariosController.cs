using BrasiliaTiendaAccesoDato.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BrasiliaTienda.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuariosController : Controller
    {
       
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
