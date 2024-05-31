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
    public class StoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stores
        public ActionResult Index() // Приказ на листата на продавници
        {
            return View(db.Stores.ToList()); // Враќање на листата на продавници од базата
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id) // Приказ на детали за конкретна продавница
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Store store = db.Stores.Find(id); // Наоѓање на продавницата со даденото ID
            if (store == null) // Доколку продавницата не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
            
            return View(store); // Враќање на поглед со деталите за продавницата
        }

        // GET: Stores/Create
        public ActionResult Create() // Приказ на формата за креирање нова продавница
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "storeID,storeName,storeAddress")] Store store) // Креирање на нова продавница
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Stores.Add(store);  // Додавање нова продавница
                db.SaveChanges(); // Зачувување на новата продавница во базата
                return RedirectToAction("Index");
            }

            return View(store); // Прикажување на формата со грешки доколку моделот не е валиден
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id) // Приказ на формата за уредување на постоечка продавница
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id); // Наоѓање на продавницата со даденото ID
            if (store == null) // Доколку продавницата не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }
            
            return View(store); // Враќање на поглед со податоците за продавницата за уредување
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "storeID,storeName,storeAddress")] Store store) // Уредување на постоечка продавница
        {
            if (ModelState.IsValid) // Проверка дали моделот е валиден
            {
                db.Entry(store).State = EntityState.Modified; // Модифицирање и зачувување на промените во базата
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(store); // Прикажување на формата со грешки доколку моделот не е валиден
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id) // Приказ на формата за бришење на продавница
        {
            if (id == null) // Проверка дали id е null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id); // Наоѓање на продавницата со даденото ID
            if (store == null) // Доколку продавницата не постои, врати HttpNotFound
            {
                return HttpNotFound();
            }

            return View(store); // Враќање на поглед со податоците за продавницата за бришење
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) // Потврда и бришење на продавницата
        {
            Store store = db.Stores.Find(id); // Наоѓање на продавницата со даденото ID
            db.Stores.Remove(store); // Бришење на продавницата од базата и зачувување на промените
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

        // GET: AddAlbumToStore
        public ActionResult AddAlbumToStore(int ID) // Приказ на формата за додавање на албум во продавница
        {
            var model = new AddAlbumToStoreModel();
            // Пополнување на моделот со податоци за продавницата и листата на албуми
            model.storeID = ID;
            model.albums = db.Albums.ToList();

            // Додавање на името на продавницата во ViewBag
            var store_n = db.Stores.Find(ID);
            if (store_n != null) // Проверка дали продавницата постои
            {
                ViewBag.StoreName = store_n.storeName;
            }

            return View(model); // Враќање на поглед со податоците за додавање на албум во продавница
        }

        // POST: AddAlbumToStore
        [HttpPost]
        public ActionResult AddAlbumToStore(AddAlbumToStoreModel model) // Додавање на албум во продавница
        {
            // Наоѓање на продавницата и албумот со дадените ID
            var store = db.Stores.Find(model.storeID);
            var album = db.Albums.Find(model.albumID);

            store.albums.Add(album); // Додавање на албумот во листата на албуми на продавницата
            db.SaveChanges(); // Зачувување на промените во базата

            return View("Index", db.Stores.ToList()); // Враќање на поглед со листата на продавници
        }
    }
}