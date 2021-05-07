using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KnjigaController : Controller
    {
        private knjigeEntities1 db = new knjigeEntities1();

        // GET: Knjiga
        public ActionResult Index(string search)
        {
            var knjigas = db.knjigas.Include(k => k.autor);
            //return View(knjigas.ToList());
            return View (knjigas.Where(a => a.autor.ime.ToLower().Contains(search) || a.autor.prezime.ToLower().Contains(search) || search==null).ToList());
           
        }
     

        // GET: Knjiga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            knjiga knjiga = db.knjigas.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // GET: Knjiga/Create
        public ActionResult Create()
        {
            ViewBag.autorID = new SelectList(db.autors, "id", "prezime");
            return View();
        }

        // POST: Knjiga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv,godina_izdanja,autorID")] knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.knjigas.Add(knjiga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.autorID = new SelectList(db.autors, "id","ime","prezime", knjiga.autorID);
            return View(knjiga);
        }

        // GET: Knjiga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            knjiga knjiga = db.knjigas.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            ViewBag.autorID = new SelectList(db.autors, "id","prezime", knjiga.autorID);
            return View(knjiga);
        }

        // POST: Knjiga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,godina_izdanja,autorID")] knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.autorID = new SelectList(db.autors, "id", "ime", "prezime", knjiga.autorID);
            return View(knjiga);
        }

        // GET: Knjiga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            knjiga knjiga = db.knjigas.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // POST: Knjiga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            knjiga knjiga = db.knjigas.Find(id);
            db.knjigas.Remove(knjiga);
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
