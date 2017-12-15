using MoviesExteme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesExteme.DAL
{
    public class MoviesExtremeDb : DbContext 
    {
        public MoviesExtremeDb() : base("ConStr")
        {

        }

        public DbSet<Clientes> Cliente { get; set; }

        public DbSet<Peliculas> Pelicula { get; set; }

        public DbSet<Facturas> Factura { get; set; }

        public DbSet<FacturasDetalles> FacturaDetalle { get; set; }



    }
}