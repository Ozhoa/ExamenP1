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
    public class AtaquesController : Controller
    {
        private DigimondContext db = new DigimondContext();

        // GET: Ataques
        public ActionResult Index()
        {
            return View(db.Ataques.ToList());
        }

        // GET: Ataques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ataque ataque = db.Ataques.Find(id);
            if (ataque == null)
            {
                return HttpNotFound();
            }
            return View(ataque);
        }

        // GET: Ataques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ataques/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreAtaque,TipoAtaque,PoderBase,DigimonId")] Ataque ataque)
        {
            if (ModelState.IsValid)
            {
                db.Ataques.Add(ataque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ataque);
        }

        // GET: Ataques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ataque ataque = db.Ataques.Find(id);
            if (ataque == null)
            {
                return HttpNotFound();
            }
            return View(ataque);
        }

        // POST: Ataques/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreAtaque,TipoAtaque,PoderBase,DigimonId")] Ataque ataque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ataque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ataque);
        }

        // GET: Ataques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ataque ataque = db.Ataques.Find(id);
            if (ataque == null)
            {
                return HttpNotFound();
            }
            return View(ataque);
        }

        // POST: Ataques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ataque ataque = db.Ataques.Find(id);
            db.Ataques.Remove(ataque);
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
