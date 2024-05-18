using Lab05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Controllers
{
    public class EventController : Controller
    {
        private static List<EventModel> eventModel = new List<EventModel>()
        {
            new EventModel()
            {
                ID = 1,
                name = "Аудиториски вежби по предметот Интернет технологии",
                location = "Амфитеатар ФИНКИ"
            },
            new EventModel()
            {
                ID = 2,
                name = "Предавање по предметот Интернет технологии",
                location = "117-ТМФ"
            },
            new EventModel()
            {
                ID = 3,
                name = "Лабораториски вежби по предметот Интернет технологии",
                location = "лаб.13-ТМФ"
            }
        };
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EventView()
        {
            return View(eventModel);
        }

        public ActionResult AddNewEvent()
        {
            EventModel model = new EventModel();

            return View(model);
        }

        private static int nextID = eventModel.Max(e => e.ID) + 1;

        [HttpPost]
        public ActionResult AddNewEvent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                //model.ID = eventModel.Count() + 1;
                //eventModel.Add(model);

                model.ID = nextID;
                nextID++;
                eventModel.Add(model);

                return RedirectToAction("EventView", "Event");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult UpdateEvent(int ID)
        {
            EventModel e_model = eventModel.Find(x => x.ID == ID);
            
            return View(e_model);
        }

        [HttpPost]
        public ActionResult UpdateEvent(EventModel model)
        {
            if (ModelState.IsValid)
            {
                EventModel e_model = eventModel.Find(x => x.ID == model.ID);
                e_model.name = model.name;
                e_model.location = model.location;

                return RedirectToAction("EventView", "Event");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult DeleteEvent(int ID)
        {
            EventModel model = eventModel.Find(x => x.ID == ID);
            eventModel.Remove(model);

            return RedirectToAction("EventView", "Event");
        }
    }
}