using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Albums.Models
{
    public class Album
    {
        public int albumID { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }
        [Required]
        public string albumName { get; set; }
        [Required]
        public string albumTitle { get; set; }
        [Range(0,5000)]
        public decimal albumPrice { get; set; }
        [Display(Name = "Image")]
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
        public virtual List<Store> stores { get; set; } // virtual поради many to many релација за соодветно мапирање од страна на базата
        public Album()
        {
            stores = new List<Store>();
        }
    }
}