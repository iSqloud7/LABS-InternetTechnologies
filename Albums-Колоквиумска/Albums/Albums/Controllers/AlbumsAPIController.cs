using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Albums.Models;

namespace Albums.Controllers
{
    public class AlbumsAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AlbumsAPI
        public List<AlbumDatatableObject> GetAlbums() // Добиј листа на албуми
        { // Селектирање на атрибутите од базата и мапирање на AlbumDatatableObject
            return db.Albums.Select(x => new AlbumDatatableObject
            {
                albumID = x.albumID,
                albumName = x.albumName,
                albumTitle = x.albumTitle,
                albumPrice = x.albumPrice,
                AlbumArtUrl = x.AlbumArtUrl
            }).ToList();
        }

        // GET: api/AlbumsAPI/5
        [ResponseType(typeof(Album))]
        public IHttpActionResult GetAlbum(int id) // Добиј албум по дадено ID
        {
            Album album = db.Albums.Find(id);
            if (album == null) // Проверка дали албумот постои
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/AlbumsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlbum(int id, Album album) // Ажурирање на албум со дадено ID
        {
            if (!ModelState.IsValid) // Проверка дали моделот е валиден
            {
                return BadRequest(ModelState);
            }

            if (id != album.albumID) // Проверка дали ID-ата се совпаѓаат
            {
                return BadRequest();
            }

            db.Entry(album).State = EntityState.Modified; // Ознака на ентитетот како изменет
            try
            {
                db.SaveChanges(); // Зачувување на промените во базата
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id)) // Проверка дали албумот постои
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent); // Враќање на статус код 204 (No Content)
        }

        // POST: api/AlbumsAPI
        [ResponseType(typeof(Album))]
        public IHttpActionResult PostAlbum(Album album) // Додавање нов албум
        {
            if (!ModelState.IsValid) // Проверка дали моделот е валиден
            {
                return BadRequest(ModelState);
            }

            db.Albums.Add(album); // Додавање на нов албум
            db.SaveChanges(); // Зачувување на новиот албум во базата

            return CreatedAtRoute("DefaultApi", new { id = album.albumID }, album); // Враќање на статус код 201 (Created) со линк до новосоздадениот албум
        }

        // DELETE: api/AlbumsAPI/5
        [Authorize(Roles = "Administrator")]
        [ResponseType(typeof(Album))]
        public IHttpActionResult DeleteAlbum(int? ID) // Бришење на албум со дадено ID (само за администратори)
        {
            Album album = db.Albums.Find(ID);
            if (album == null) // Проверка дали албумот постои
            {
                return NotFound();
            }

            db.Albums.Remove(album); // Бришење на албумот од базата
            db.SaveChanges(); // Зачувување на промените во базата

            return Ok(album); // Враќање на избришаниот албум
        }

        protected override void Dispose(bool disposing) // Ослободување на ресурси
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlbumExists(int id) // Проверка дали албумот постои во базата
        {
            return db.Albums.Count(e => e.albumID == id) > 0;
        }
    }
}