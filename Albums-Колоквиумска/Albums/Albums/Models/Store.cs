using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albums.Models
{
    public class Store
    {
        public int storeID { get; set; }
        [Required]
        public string storeName { get; set; }
        public string storeAddress { get; set; }
        public virtual List<Album> albums { get; set; }
        public Store()
        {
            albums = new List<Album>();
        }
    }
}