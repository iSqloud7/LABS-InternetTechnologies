using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albums.Models
{
    public class Genre
    {
        [Display(Name = "ID")]
        public int genreID { get; set; }
        [Display(Name = "Genre Name")]
        public string genreName { get; set; }
        public string genreDescription { get; set; }
        public List<Album> Albums { get; set; }
    }
}