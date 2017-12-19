using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesExteme.Models
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }

        public int ClienteId { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadPelicula { get; set; }

        public decimal SubTotal { get; set; } 
        
        public decimal Total { get; set; }

        public Facturas()
        {

        }
    }
}