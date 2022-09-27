using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using System.ComponentModel.DataAnnotations.Schema;
using BrasiliaTiendaModelo.Models;

namespace BrasiliaTiendaModelo
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="El nombre es obligatorio")]
        [Display(Name ="Nombre del Articulo")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatorio")]
        public string? Descripcion { get; set; }


        [Display(Name = "Fecha de Creacion")]
        public string? FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? UrlImagen { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }



    }
}
