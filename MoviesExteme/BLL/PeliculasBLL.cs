using MoviesExteme.DAL;
using MoviesExteme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesExteme.BLL
{
    public class PeliculasBLL
    {
        public static bool Guardar(Peliculas pelicula)
        {
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    db.Pelicula.Add(pelicula);
                    if (db.SaveChanges() > 0)
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
        public static Peliculas Buscar(int? peliculaId)
        {
            Peliculas pelicula = null;
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    pelicula = db.Pelicula.Find(peliculaId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return pelicula;
        }

        public static bool Modificar(Peliculas pelicula)
        {
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    db.Entry(pelicula).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                        return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public static bool Eliminar(Peliculas pelicula)
        {
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    db.Entry(pelicula).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                        return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        public static List<Peliculas> Listar()
        {
            List<Peliculas> listado = null;
            using (var db = new MoviesExtremeDb())
            {
                try
                {
                    listado = db.Pelicula.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }

        public static bool Eliminar(int? peliculaId)
        {
            try
            {
                return Eliminar(Buscar(peliculaId));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}