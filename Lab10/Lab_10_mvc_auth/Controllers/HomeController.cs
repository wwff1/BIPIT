using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_10_mvc_auth.Models;

namespace Lab_10_mvc_auth.Controllers
{
    public class HomeController : Controller
    {
        RentBusEntities rent = new RentBusEntities();
        public ActionResult Index()
        {
            
            ViewBag.Clients = DoMagic("id_Client", "FIO",1);
            ViewBag.Bus = DoMagic("id_Bus", "Name_car",2);
            ViewBag.Orders = DoMagic("id_Order", "Order", 3);
            ViewData["Order"] = rent.Order;

            return View();
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

        public ActionResult Add_order(FormCollection form)
        {

            var client = int.Parse(form["id_client"]);
            var bus = int.Parse(form["id_bus"]);
            var date = DateTime.Parse(form["date"]);
            var cost = int.Parse(form["cost"]);

         
            rent.Order.Add(new Order
            {
                id_Client_FK = client,
                id_Bus_FK = bus,
                date = date,
                cost = cost
            });
            rent.SaveChanges();

            return Redirect(Url.Action("Index", "Home"));
        }


        public ActionResult Delete(int id)
        {
            var order = rent.Order.FirstOrDefault(x => x.id_Order == id);
            rent.Order.Remove(order);
            rent.SaveChanges();
            return Redirect(Url.Action("Index", "Home"));
        }

        public ActionResult Change_order(FormCollection form)
        {

            var id = int.Parse(form["id_Order_edit"]);
            var client = int.Parse(form["id_client_edit"]);
            var bus = int.Parse(form["id_bus_edit"]);
            var date = DateTime.Parse(form["date_edit"]);
            var cost = int.Parse(form["cost_edit"]);

            var order = rent.Order.FirstOrDefault(x => x.id_Order == id);
            order.id_Client_FK = client;
            order.id_Bus_FK = bus;
            order.date = date;
            order.cost = cost;

            rent.SaveChanges();

            return Redirect(Url.Action("Index", "Home"));
        }

        [NonAction]
        public SelectList DoMagic(string valueField, string textField, int flag)
        {
            var dt = new DataTable();
            dt.Columns.Add(valueField);
            dt.Columns.Add(textField);
            switch (flag)
            {
                case 1:
                {
                    foreach (var entity in rent.Client) 
                        dt.Rows.Add(entity.id_Client, entity.FIO);
                    break;
                }
                case 2:
                {
                    foreach (var entity in rent.Bus)
                        dt.Rows.Add(entity.id_Bus, entity.Name_car);
                    break;
                }
                case 3:
                {
                    foreach (var entity in rent.Order)
                        dt.Rows.Add(entity.id_Order, entity.id_Order);
                    break;
                }
            }

            return new SelectList((from DataRow row in dt.Rows select new SelectListItem() 
                { Text = row[textField].ToString(), Value = row[valueField].ToString() }).ToList(),
                "Value", "Text");
        }
    }
}