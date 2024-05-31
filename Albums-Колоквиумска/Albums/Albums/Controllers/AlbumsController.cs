using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Web;
using System.Web.Mvc;
using Albums.Models;

namespace Albums.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Albums
        public ActionResult Index() // Приказ на листата од албуми
        {
            if (User.IsInRole("User")) // Ако корисникот е во улога "User", прикажи IndexAjax поглед
            {
                return View("IndexAjax"); // поглед само на DataTable
            }

            // Ако корисникот е "Editor" или "Administrator", прикажи ја вистинската Index табела со копчиња
            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return View(albums.ToList());
        }

        // GET: Albums
        public ActionResult IndexAjax() // Приказ на листата од албуми во jQueryDataTable, load со Ajax
        {
            return View();
        }

        // GET: Albums/Details/5
        [Authorize(Roles = "User")] // на Details акцијата да може само улога User да пристапи
        public ActionResult Details(int? ID)
        {
            if (ID == null) // Проверка дали ID е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album; // Наоѓање на албумот со даденото ID, вклучувајќи ги жанрот и артистот
            album = db.Albums.Include(d => d.Genre).SingleOrDefault(d => d.GenreID == ID);
            album = db.Albums.Include(d => d.Artist).SingleOrDefault(d => d.ArtistID == ID);
            // Album album = db.Albums.Find(ID);

            if (album == null) // Доколку албумот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create() // Приказ на формата за креирање нов албум
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "artistID", "artistName");
            ViewBag.GenreID = new SelectList(db.Genres, "genreID", "genreName");
            return View();
        }

        // POST: Albums/Create
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "albumID,GenreID,ArtistID,albumName,albumTitle,albumPrice,AlbumArtUrl")] Album album) // Креирање на нов албум
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Albums.Add(album); // Додавање на новиот албум
                db.SaveChanges(); // Зачувување на новиот албум во базата
                return RedirectToAction("Index");
            }
            // Повторно полнење на SelectList и прикажување на формата доколку има грешки
            ViewBag.ArtistID = new SelectList(db.Artists, "artistID", "artistName", album.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "genreID", "genreName", album.GenreID);
            return View(album);
        }

        // GET: Albums/Edit/5
        [Authorize(Roles = "Administrator, Editor")]
        public ActionResult Edit(int? id) // Приказ на формата за уредување на постоечки албум
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = db.Albums.Find(id);  // Наоѓање на албумот со даденото ID
            if (album == null) // Доколку албумот не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
            // Полнење на SelectList и прикажување на формата за уредување
            ViewBag.ArtistID = new SelectList(db.Artists, "artistID", "artistName", album.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "genreID", "genreName", album.GenreID);
            return View(album);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "albumID,GenreID,ArtistID,albumName,albumTitle,albumPrice,AlbumArtUrl")] Album album) // Уредување на постоечки албум
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Entry(album).State = EntityState.Modified; // Модифицирање
                db.SaveChanges(); // Зачувување на промените во базата
                return RedirectToAction("Index");
            }
            // Повторно полнење на SelectList и прикажување на формата доколку има грешки
            ViewBag.ArtistID = new SelectList(db.Artists, "artistID", "artistName", album.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres, "genreID", "genreName", album.GenreID);
            return View(album);
        }
        /*
        // за да работи Delete со Ajax
        GET: Albums/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }
        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        // GET: Albums/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Delete(int? ID) // Бришење на албум со дадено ID, само за улога "Administrator"
        {
            Album album = db.Albums.Find(ID); // Наоѓање на албумот со даденото ID
            db.Albums.Remove(album); // Бришење на албумот од базата
            db.SaveChanges(); // Зачувување на промените
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
