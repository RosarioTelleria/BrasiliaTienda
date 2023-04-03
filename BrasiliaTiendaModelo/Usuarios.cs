using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrasiliaTiendaModelo
{
    public  class Usuarios
    {
        public DateTime lockoutEnd;

        [Key]
        public string IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Articulo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }
        public string Direccion { get; set; }

    }
}
