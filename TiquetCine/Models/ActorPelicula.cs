using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiquetCine.Models
{
    public class ActorPelicula
    {
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }


    }
}
