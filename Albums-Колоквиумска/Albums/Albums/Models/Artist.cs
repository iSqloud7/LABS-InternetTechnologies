using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albums.Models
{
    public class Artist
    {
        public int artistID { get; set; }
        [Display(Name = "Artist Name")]
        [Required]
        public string artistName { get; set; }
    }
}