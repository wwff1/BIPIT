using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_9_MVC.Models;

namespace Lab_9_MVC.Controllers
{
    public class DefaultController : Controller
    {
        RentBusEntities rent = new RentBusEntities();
        public ActionResult Index()
        {
            return View(rent.Order.ToList());
        }

        public ActionResult Clients()
        {
            ViewBag.Message = "Клиенты";

            return View(rent.Client.ToList());
        }

        public ActionResult Bus()
        {
            ViewBag.Message = "Автобусы";

            return View(rent.Bus.ToList());
        }
    }
}