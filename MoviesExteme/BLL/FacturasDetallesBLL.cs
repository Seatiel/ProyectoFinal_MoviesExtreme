using MoviesExteme.DAL;
using MoviesExteme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesExteme.BLL
{
    public class FacturasDetallesBLL
    {
        public static bool Guardar(FacturasDetalles detalle)
        {
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    db.FacturaDetalle.Add(detalle);
                    if (db.SaveChanges() > 0)
                    {
                        var pelicula = BLL.PeliculasBLL.Buscar(detalle.PeliculaId);
                        if (pelicula.PeliculaId> 1)
                        {
                            pelicula.Existencia = pelicula.Existencia - detalle.Cantidad;
                            return BLL.PeliculasBLL.Modificar(pelicula);
                        }
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static FacturasDetalles Buscar(int? detalleId)
        {
            FacturasDetalles detail = null;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    detail = conexion.FacturaDetalle.Find(detalleId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return detail;
        }
        public static bool Modificar(FacturasDetalles detalle)
        {
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    if (Buscar(detalle.Id) != null)
                    {
                        conexion.Entry(detalle).State = EntityState.Modified;
                        if (conexion.SaveChanges() > 0)
                            return true;
                    }
                    else
                    {
                        return Guardar(detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static bool Eliminar(FacturasDetalles detalle)
        {
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    var pelicula = BLL.PeliculasBLL.Buscar(detalle.PeliculaId);
                    int cant = detalle.Cantidad;

                    conexion.Entry(detalle).State = EntityState.Deleted;
                    if (conexion.SaveChanges() > 0)
                    {
                        if (pelicula.PeliculaId > 1)
                        {
                            pelicula.Existencia = pelicula.Existencia + cant;
                            return BLL.PeliculasBLL.Modificar(pelicula);
                        }
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }
        public static List<FacturasDetalles> Listar()
        {
            List<FacturasDetalles> listado = null;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    listado = conexion.FacturaDetalle.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static List<FacturasDetalles> Listar(int? facturaId)
        {
            List<FacturasDetalles> listado = null;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    listado = conexion.FacturaDetalle.
                        Where(d => d.FacturaId == facturaId).
                        OrderBy(d => d.Id).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Guardar(List<FacturasDetalles> detalles)
        {
            bool resultado = false;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    foreach (FacturasDetalles detail in detalles)
                    {
                        resultado = Guardar(detail);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static bool Modificar(List<FacturasDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (FacturasDetalles detail in detalles)
                {
                    resultado = Modificar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
        public static bool Eliminar(int? detalleId)
        {
            try
            {
                return Eliminar(Buscar(detalleId));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool Eliminar(List<FacturasDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (var detail in detalles)
                {
                    resultado = Eliminar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
    }
}