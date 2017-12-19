using MoviesExteme.DAL;
using MoviesExteme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MoviesExteme.BLL
{
    public class FacturasBLL
    {
        public static bool Guardar(EncabezadoDetalle factura)
        {
            bool resultado = false;
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    db.Factura.Add(factura.Encabezado);
                    if (db.SaveChanges() > 0)
                    {
                        resultado = BLL.FacturasDetallesBLL.Guardar(factura.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static Facturas Buscar(int facturaId)
        {
            Facturas factura = null;
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    factura = db.Factura.Find(facturaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return factura;
        }

        public static EncabezadoDetalle Buscar(int? facturaId)
        {
            EncabezadoDetalle factura = null;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    factura = new EncabezadoDetalle()
                    {
                        Encabezado = conexion.Factura.Find(facturaId)
                    };
                    if (factura.Encabezado != null)
                    {
                        factura.Detalle =
                        BLL.FacturasDetallesBLL.Listar(factura.Encabezado.FacturaId);
                    }
                    else
                    {
                        factura = null;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return factura;
        }

        public static bool Modificar(EncabezadoDetalle factura)
        {
            bool resultado = false;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    conexion.Entry(factura.Encabezado).State = EntityState.Modified;
                    if (conexion.SaveChanges() > 0)
                    {
                        resultado = FacturasDetallesBLL.Modificar(factura.Detalle);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static bool Eliminar(EncabezadoDetalle factura)
        {
            bool resultado = false;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    if (BLL.FacturasDetallesBLL.Eliminar(factura.Detalle))
                    {
                        conexion.Entry(factura.Encabezado).State = EntityState.Deleted;
                        resultado = conexion.SaveChanges() > 0;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }

        public static List<Facturas> Listar()
        {
            List<Facturas> listado = null;
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    listado = db.Factura.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        //public static List<Facturas> Listar()
        //{
        //    List<Facturas> listado = null;
        //    using (var conexion = new MoviesExtremeDb())
        //    {
        //        try
        //        {
        //            listado = conexion.Factura.OrderBy(f => f.Fecha).ToList();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    return listado;
        //}

        public static List<Facturas> Listar(int? clienteId)
        {
            List<Facturas> listado = null;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    listado = conexion.Factura.
                    Where(f => f.ClienteId == clienteId).
                    OrderBy(f => f.Fecha).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        
        public static bool Eliminar(int? facturaId)
        {
            try
            {
                return Eliminar(Buscar(facturaId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool Guardar(Facturas factura)
        {
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    conexion.Factura.Add(factura);
                    if (conexion.SaveChanges() > 0)
                    {
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

        public static Facturas BuscarEncabezado(int? facturaId)
        {
            Facturas factura = null;
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    factura = conexion.Factura.Find(facturaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return factura;
        }

        public static bool EliminarEncabezado(int? facturaId)
        {
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    conexion.Entry(BuscarEncabezado(facturaId)).State = EntityState.Deleted;
                    if (conexion.SaveChanges() > 0)
                    {
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

        public static bool ModificarEncabezado(int? facturaId)
        {
            using (var conexion = new MoviesExtremeDb())
            {
                try
                {
                    conexion.Entry(BuscarEncabezado(facturaId)).State = EntityState.Modified;
                    if (conexion.SaveChanges() > 0)
                    {
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

        public static int Identity()
        {
            int identity = 0;
            string con =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\seati\OneDrive for Business 1\Diplomado ITLA\MoviesExteme\MoviesExteme\App_Data\MoviesExtremeDb.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection db = new SqlConnection(con))
            {
                try
                {
                    db.Open();
                    SqlCommand comando = new SqlCommand("SELECT IDENT_CURRENT('Ventas')", db);
                    identity = Convert.ToInt32(comando.ExecuteScalar());
                    db.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return identity;
        }

    }
}