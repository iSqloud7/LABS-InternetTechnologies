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
    public class GenresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Genres
        public ActionResult Index() // Приказ на листата на жанрови
        {
            return View(db.Genres.ToList()); // Враќање на листата на жанрови од базата
        }

        // GET: Genres/Details/5
        public ActionResult Details(int? id) // Приказ на детали за конкретен жанр
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Genre genre = db.Genres.Find(id); // Наоѓање на жанрот со даденото ID
            if (genre == null) // Доколку жанрот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
            
            return View(genre); // Враќање на поглед со деталите за жанрот
        }

        // GET: Genres/Create
        public ActionResult Create() // Приказ на формата за креирање нов жанр
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "genreID,genreName,genreDescription")] Genre genre) // Креирање на нов жанр
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Genres.Add(genre); // Додавање на нов жанр
                db.SaveChanges(); // Зачувување на новиот жанр во базата
                return RedirectToAction("Index");
            }
            
            return View(genre); // Прикажување на формата со грешки доколку моделот не е валиден
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int? id) // Приказ на формата за уредување на постоечки жанр
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id); // Наоѓање на жанрот со даденото ID
            if (genre == null) // Доколку жанрот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
            
            return View(genre); // Враќање на поглед со податоците за жанрот за уредување
        }

        // POST: Genres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "genreID,genreName,genreDescription")] Genre genre) // Уредување на постоечки жанр
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Entry(genre).State = EntityState.Modified; // Модифицирање и зачувување на промените во базата
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(genre); // Прикажување на формата со грешки доколку моделот не е валиден
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int? id) // Приказ на формата за бришење на жанр
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = db.Genres.Find(id); // Наоѓање на жанрот со даденото ID
            if (genre == null) // Доколку жанрот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
            
            return View(genre); // Враќање на поглед со податоците за жанрот за бришење
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) // Потврда и бришење на жанрот
        {
            Genre genre = db.Genres.Find(id); // Наоѓање на жанрот со даденото ID
            db.Genres.Remove(genre); // Бришење на жанрот од базата и зачувување на промените
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