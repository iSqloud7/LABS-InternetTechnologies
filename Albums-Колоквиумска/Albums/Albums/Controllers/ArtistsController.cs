using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Albums.Models;

namespace Albums.Controllers
{
    public class ArtistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Artists
        public ActionResult Index() // Приказ на листата на артисти
        {
            return View(db.Artists.ToList()); // Враќање на листата на артисти од базата
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id) // Приказ на детали за конкретен артист
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artist artist = db.Artists.Find(id); // Наоѓање на артистот со даденото ID
            if (artist == null) // Доколку артистот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }

            return View(artist); // Враќање на поглед со деталите за артистот
        }

        // GET: Artists/Create
        public ActionResult Create() // Приказ на формата за креирање нов артист
        {
            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "artistID,artistName")] Artist artist) // Креирање на нов артист
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Artists.Add(artist); // Додавањe на нов артист
                db.SaveChanges(); // Зачувување на новиот артист во базата
                return RedirectToAction("Index");
            }
            // Прикажување на формата со грешки доколку моделот не е валиден
            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id) // Приказ на формата за уредување на постоечки артист
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Artist artist = db.Artists.Find(id); // Наоѓање на артистот со даденото ID
            if (artist == null) // Доколку артистот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }

            return View(artist); // Враќање на поглед со податоците за артистот за уредување
        }

        // POST: Artists/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "artistID,artistName")] Artist artist) // Уредување на постоечки артист
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Entry(artist).State = EntityState.Modified; // Модифицирање и зачувување на промените во базата
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(artist); // Прикажување на формата со грешки доколку моделот не е валиден
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id) // Приказ на формата за бришење на артист
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Artist artist = db.Artists.Find(id); // Наоѓање на артистот со даденото ID
            if (artist == null) // Доколку артистот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
           
            return View(artist); // Враќање на поглед со податоците за артистот за бришење
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) // Потврда и бришење на артистот
        {
            Artist artist = db.Artists.Find(id); // Наоѓање на артистот со даденото ID
            db.Artists.Remove(artist); // Бришење на артистот од базата и зачувување на промените
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) // Ослободување на ресурси
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}