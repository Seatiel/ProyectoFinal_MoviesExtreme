using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesExteme.Models
{
    public class FacturasDetalles
    {
        public int Id { get; set; }

        public int FacturaId { get; set; }

        public int PeliculaId { get; set; }

        public string Titulo { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }        

        public FacturasDetalles()
        {

        }
    }
}