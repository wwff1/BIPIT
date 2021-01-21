using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab_11_Web_api.Models;

namespace Lab_11_Web_api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private readonly RentBusEntities _rent = new RentBusEntities();

        ValuesController()
        {
            _rent.Configuration.ProxyCreationEnabled = false;
        }



        #region Order

        [Route("~/api/GetOrders")]
        [HttpGet]
        public IEnumerable<Order> GetOrders() => _rent.Order;

        [Route("~/api/AddOrder")]
        [HttpPost]
        public void AddOrder([FromBody] Order order)
        {
            _rent.Order.Add(order);
            _rent.SaveChanges();
        }

        [Route("~/api/DeleteOrder/{id?}")]
        [HttpDelete]
        public void DeleteOrder(int id)
        {
            var order = new Order() { id_Order = id };
            _rent.Order.Attach(order);
            _rent.Order.Remove(order);
            _rent.SaveChanges();
        }

        #endregion



        #region Client

        [Route("~/api/GetClients")]
        [HttpGet]
        public IEnumerable<Client> GetClients() => _rent.Client;

        [Route("~/api/AddClient")]
        [HttpPost]
        public void AddClient([FromBody] Client client)
        {
            _rent.Client.Add(client);
            _rent.SaveChanges();
        }

        [Route("~/api/DeleteClient/{id?}")]
        [HttpDelete]
        public void DeleteClient(int id)
        {
            var client = new Client() { id_Client = id };
            _rent.Client.Attach(client);
            _rent.Client.Remove(client);
            _rent.SaveChanges();
        }

        #endregion


        #region Bus

        [Route("~/api/GetBus")]
        [HttpGet]
        public IEnumerable<Bus> GetBus() => _rent.Bus;

        [Route("~/api/AddBus")]
        [HttpPost]
        public void AddBus([FromBody] Bus bus)
        {
            _rent.Bus.Add(bus);
            _rent.SaveChanges();
        }

        [Route("~/api/DeleteBus/{id?}")]
        [HttpDelete]
        public void DeleteBus(int id)
        {
            var bus = new Bus() { id_Bus = id };
            _rent.Bus.Attach(bus);
            _rent.Bus.Remove(bus);
            _rent.SaveChanges();
        }

        #endregion


        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
