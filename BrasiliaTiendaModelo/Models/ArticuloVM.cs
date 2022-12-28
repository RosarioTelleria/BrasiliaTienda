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
    public class ArticuloVM
    {
        public Articulo? Articulo { get; set; }

        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }
    }
}
