using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiquetCine.Models
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Display(Name = "Foto de Perfil")]
        [Required(ErrorMessage = "Se requiere la foto de perfil")]
        public string Foto { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre")]
        [StringLength(50, MinimumLength= 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Biografia")]
        [Required(ErrorMessage = "Se requiere la biografia")]
        public string Biografia { get; set; }

        //relaciones
        public List<ActorPelicula> ActorPeliculas { get; set; }

    }
}
