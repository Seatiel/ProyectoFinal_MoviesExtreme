using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesExteme.Models
{
    public class Peliculas
    {
        [Key]
        public int PeliculaId { get; set; }

        public string Titulo { get; set; }

        public string Genero { get; set; }

        public int Existencia { get; set; }

        public int Duracion { get; set; } 
        
        public decimal Precio { get; set; }

        public Peliculas()
        {

        }
    }
}