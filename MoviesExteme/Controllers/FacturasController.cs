using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesExteme.DAL;
using MoviesExteme.Models;
using MoviesExteme.BLL;

namespace MoviesExteme.Controllers
{
    public class FacturasController : Controller
    {
        private MoviesExtremeDb db = new MoviesExtremeDb();

        public ActionResult Index()
        {
            return View(FacturasBLL.Listar());
        }

        [HttpGet]
        public JsonResult LastIndex()
        {
            int id = FacturasBLL.Identity();
            if (id > 1 || FacturasBLL.Listar().Count > 0)
                ++id;
            return Json(id);
        }

        [HttpGet]
        public JsonResult Buscar(int facturaId)
        {
            Facturas factura = FacturasBLL.Buscar(facturaId);
            return Json(factura);
        }

        [HttpGet]
        public JsonResult BuscarVentas(int facturaId)
        {
            var factura = FacturasBLL.Listar();
            return Json(factura);
        }

        [HttpPost]
        public JsonResult GuardarVentas(EncabezadoDetalle factura)
        {
            bool resultado = false;
            if (ModelState.IsValid)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    int y, m, d, h, min, s;
                    y = factura.Encabezado.Fecha.Year;
                    m = factura.Encabezado.Fecha.Month;
                    d = factura.Encabezado.Fecha.Day;
                    h = now.Hour;
                    min = now.Minute;
                    s = now.Second;
                    factura.Encabezado.Fecha = new DateTime(y, m, d, h, min, s);
                    resultado = FacturasBLL.Guardar(factura);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Json(resultado);
        }        

        [HttpGet]
        public JsonResult ListaPeliculas(int id)
        {
            var listado = PeliculasBLL.Listar();
            return Json(listado);
        }

        // GET: Facturas
        //public ActionResult Index()
        //{
        //    return View(db.Factura.ToList());
        //}

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Factura.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaId,ClienteId,Fecha,CantidadPelicula,SubTotal,Total")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Factura.Add(facturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Factura.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaId,ClienteId,Fecha,CantidadPelicula,SubTotal,Total")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facturas);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Factura.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facturas facturas = db.Factura.Find(id);
            db.Factura.Remove(facturas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
