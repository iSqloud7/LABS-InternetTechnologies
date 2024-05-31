using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Albums.Models
{
    public class AddAlbumToStoreModel
    {
        public int storeID { get; set; } // за која продавница се однесува
        public int albumID { get; set; } // за кој албум се однесува
        public List<Album> albums { get; set; } // приказ на сите албуми
        public AddAlbumToStoreModel()
        {
            albums = new List<Album>();
        }
    }
}