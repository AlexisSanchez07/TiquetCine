using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiquetCine.Models
{
    public class Productor
    {
        [Key]
        public int ProductorId { get; set; }
        [Display(Name = "Foto de Perfil")]
        public string Foto { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Biografia")]
        public string Biografia { get; set; }

        //Relaciones
        public List<Pelicula> Peliculas { get; set; }
    }
}
