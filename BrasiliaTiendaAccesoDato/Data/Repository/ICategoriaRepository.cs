using BrasiliaTiendaModelo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasiliaTiendaAccesoDato.Data.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<SelectListItem> GetListaCategoria();

        void Update(Categoria categoria);
    }
}
