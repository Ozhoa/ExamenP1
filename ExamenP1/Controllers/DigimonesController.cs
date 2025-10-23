using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenP1.Models;

namespace ExamenP1.Controllers
{
    public class DigimonesController : Controller
    {
        private DigimondContext db = new DigimondContext();

        // GET: Digimones
        public ActionResult Index()
        {
            return View(db.Digimones.ToList());
        }

        // GET: Digimones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Digimon digimon = db.Digimones.Find(id);
            if (digimon == null)
            {
                return HttpNotFound();
            }
            return View(digimon);
        }

        // GET: Digimones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Digimones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Nivel,Tipo,Elemento")] Digimon digimon)
        {
            if (ModelState.IsValid)
            {
                db.Digimones.Add(digimon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(digimon);
        }

        // GET: Digimones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Digimon digimon = db.Digimones.Find(id);
            if (digimon == null)
            {
                return HttpNotFound();
            }
            return View(digimon);
        }

        // POST: Digimones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Nivel,Tipo,Elemento")] Digimon digimon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(digimon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(digimon);
        }

        // GET: Digimones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Digimon digimon = db.Digimones.Find(id);
            if (digimon == null)
            {
                return HttpNotFound();
            }
            return View(digimon);
        }

        // POST: Digimones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Digimon digimon = db.Digimones.Find(id);
            db.Digimones.Remove(digimon);
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
