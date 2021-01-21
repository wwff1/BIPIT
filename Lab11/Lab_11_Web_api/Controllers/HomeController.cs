using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_11_Web_api.Models;

namespace Lab_11_Web_api.Controllers
{
    public class HomeController : Controller
    {
        RentBusEntities rent = new RentBusEntities();
        public ActionResult Index()=>View();

        public ActionResult Clients()
        {
            ViewBag.Message = "Клиенты";

            return View();
        }

        public ActionResult Bus()
        {
            ViewBag.Message = "Автобусы";
            return View();
        }

    }
}
