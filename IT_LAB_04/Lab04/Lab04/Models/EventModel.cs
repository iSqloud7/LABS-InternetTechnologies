using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab04.Models
{
    public class EventModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Името на настанот е задолжително.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Локацијата на настанот е задолжителна.")]
        public string location { get; set; }
    }
}