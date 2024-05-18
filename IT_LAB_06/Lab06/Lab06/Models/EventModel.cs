using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab06.Models
{
    public class EventModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Името е задолжително")]
        public string name { get; set; }
        [Required(ErrorMessage = "Локацијата е задолжителна")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Локацијата мора да биде помеѓу 5 и 30 карактери")]
        public string location { get; set; }
    }
}