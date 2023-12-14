using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TiquetCine.Data;

namespace TiquetCine.Models
{
    public class Pelicula
    {
        [Key]
        public int PeliculaId { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere el nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Se requiere la Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Se requiere el Precio")]
        public double Precio { get; set; }
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "Se requiere la foto de la pelicula")]
        public string ImageURL { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "Se requiere la fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha Final")]
        [Required(ErrorMessage = "Se requiere la fecha de final")]
        public DateTime FechaFinal { get; set; }

        public Categoria Categoria { get; set; }

        //relaciones

        public List<ActorPelicula> ActorPeliculas { get; set; }

        //Cine
        public int CineId { get; set; }
        [ForeignKey("CineId")]
        public Cine Cine { get; set; }


        //Productor
        public int ProductorId { get; set; }
        [ForeignKey("ProductorId")]
        public Productor Productor { get; set; }




    }
}
