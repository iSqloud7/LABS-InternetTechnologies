using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albums.Models
{
    public class AlbumDatatableObject
    {
        // сите елементи од Album моделот, без објекти од друг тип, ICollections, виртуелни класи итн.
        public int albumID { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }
        public string albumName { get; set; }
        public string albumTitle { get; set; }
        public decimal albumPrice { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
    }
}