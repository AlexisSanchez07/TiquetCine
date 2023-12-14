using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiquetCine.Models
{
    public class Cine
    {
        [Key]
        public int CineId { get; set; }
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "Se requiere la foto de perfil")]
        public string Foto { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Se requiere la Descripcion")]
        public string Biografia { get; set; }

        //Relaciones
        public List<Pelicula> Peliculas { get; set; }
    }
}
