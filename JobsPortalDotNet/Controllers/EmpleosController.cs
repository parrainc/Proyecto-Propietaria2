using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsPortalDotNet.Controllers
{
    public class EmpleosController : Controller
    {
        private proyecto_empleosEntities1 db = new proyecto_empleosEntities1();

        //
        // GET: /Empleos/

        public ActionResult Index(int page=0)
        {
           /* const int PageSize = 5;

            var count = this.db.empleos.Count();
            var empleos = this.db.empleos.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize ==0 ? 1 : 0);
            this.ViewBag.Page = page;*/

            var empleos = db.empleos.Include(e => e.categoria1).Include(e => e.usuario).ToList();
            return View(empleos);
        }

        //
        // GET: /Empleos/Details/5

        public ActionResult Details(int id = 0)
        {
            empleo empleo = db.empleos.Find(id);
            if (empleo == null)
            {
                return HttpNotFound();
            }
            return View(empleo);
        }

        //
        // GET: /Empleos/Create

        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.categorias, "id", "descripcion");
            ViewBag.published_by = new SelectList(db.usuarios, "id", "nombre");
            return View();
        }

        //
        // POST: /Empleos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(empleo empleo)
        {
            if (ModelState.IsValid)
            {
                db.empleos.Add(empleo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.categorias, "id", "descripcion", empleo.categoria);
            ViewBag.published_by = new SelectList(db.usuarios, "id", "nombre", empleo.published_by);
            return View(empleo);
        }

        //
        // GET: /Empleos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            empleo empleo = db.empleos.Find(id);
            if (empleo == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.categorias, "id", "descripcion", empleo.categoria);
            ViewBag.published_by = new SelectList(db.usuarios, "id", "nombre", empleo.published_by);
            return View(empleo);
        }

        //
        // POST: /Empleos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(empleo empleo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.categorias, "id", "descripcion", empleo.categoria);
            ViewBag.published_by = new SelectList(db.usuarios, "id", "nombre", empleo.published_by);
            return View(empleo);
        }

        //
        // GET: /Empleos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            empleo empleo = db.empleos.Find(id);
            if (empleo == null)
            {
                return HttpNotFound();
            }
            return View(empleo);
        }

        //
        // POST: /Empleos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empleo empleo = db.empleos.Find(id);
            db.empleos.Remove(empleo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}