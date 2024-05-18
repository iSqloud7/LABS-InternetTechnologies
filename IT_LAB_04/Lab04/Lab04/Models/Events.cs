using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab04.Models
{
    public class Events
    {
        public List<EventModel> eventModel { get; set; }
        public Events()
        {
            this.eventModel = new List<EventModel>();
        }
    }
}