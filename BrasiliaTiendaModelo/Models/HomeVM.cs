using BrasiliaTiendaModelo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasiliaTiendaModelo.ViewModels
{
    public class HomeVM
    {
        
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Articulo> Articulo { get; set; }
    }
}
