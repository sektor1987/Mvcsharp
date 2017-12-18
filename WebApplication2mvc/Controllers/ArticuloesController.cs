using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2mvc.Models;

namespace WebApplication2mvc.Controllers
{
    public class ArticuloesController : Controller
    {
        private Entities db = new Entities();

        // GET: Articuloes
        //HINT: verificamos si el usuario esta logueado
        [Authorize]
        //https://stackoverflow.com/questions/30658315/c-sharp-mvc5-easy-way-to-check-if-user-is-authenticated-in-each-controller-met/30658341
        public ActionResult Index(string searchString)
        {
            var articulos = from s in db.Articulos
                            select s;
            //filtro de nombre
            if (!String.IsNullOrEmpty(searchString))
            {
                articulos = articulos.Where(s => s.NombreArticulo.Contains(searchString));
            }
            //HINT: verificamos si el usuario esta logueado
            return View(articulos.ToList());
        }

        // GET: Articuloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        //Hint: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
        //public ActionResult buscarPorNombre(string nombre)
        //{

        //    string filtro = "";

        //    if (nombre != "" && nombre != null)
        //    {
        //        filtro = nombre;
        //    }

        //    var listaFiltrada = db.Articulos.Where(r => r.NombreArticulo.Contains(nombre)).ToList();

        //    return View(listaFiltrada);
        //    return View(students.ToPagedList(pageNumber, pageSize));

        //}

        // GET: Articuloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articuloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreArticulo,DescArticulo,PrecioArt,UnidadesExistencia")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articulo);
        }

        // GET: Articuloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreArticulo,DescArticulo,PrecioArt,UnidadesExistencia")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articulo);
        }

        // GET: Articuloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulos.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articuloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulos.Find(id);
            db.Articulos.Remove(articulo);
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
