using BrasiliaTienda.Models;
using BrasiliaTiendaAccesoDato.Data.Repository;
using BrasiliaTiendaModelo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrasiliaTienda.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Slider = _contenedorTrabajo.Slider.GetAll(),
                Articulo = _contenedorTrabajo.Articulo.GetAll()

            };
            return View(homeVM);    
        }

    }
}