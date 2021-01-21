using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;



namespace Lab_4_CSharp
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }
        [WebMethod]
        public string InsertMethod(string id_Client, string id_Bus, string date, string cost)
        {
            using (var rentDB = new RentBusEntities())
            {
                var order = rentDB.Order;
                var OrderToAdd = new Order
                {
                    id_Client_FK = int.Parse(id_Client),
                    id_Bus_FK = int.Parse(id_Bus),
                    date = DateTime.Parse(date),
                    cost = int.Parse(cost)
                };
                order.Add(OrderToAdd);
                rentDB.SaveChanges();
            }
            return "Готово";
        }

        [WebMethod]
        public DataTable GetData(string dateFirst, string dateSecond)
        {
            using (var rentDB = new RentBusEntities())
            {
                var order = rentDB.Order;
                var columns = new List<string> { "id_Order", "id_Client_FK", "FIO", "id_Bus_FK", "Name_car", "date", "cost" };
                using (var dt = new DataTable())
                {
                    dt.TableName = "Order";
                    foreach (var VARIABLE in columns)
                        dt.Columns.Add(VARIABLE);
                    if (string.IsNullOrEmpty(dateFirst) || string.IsNullOrEmpty(dateSecond))
                    {
                        foreach (var item in order)
                            FillRowRent(dt, item);
                        return dt;
                    }
                    foreach (var item in order)
                        if (DateTime.Parse(dateFirst) <= item.date && item.date <= DateTime.Parse(dateSecond))
                            FillRowRent(dt, item);
                    return dt;
                }
            }
        }

        private void FillRowRent(DataTable dt,Order item)
        {
            var row = dt.NewRow();
            row["id_Order"] = item.id_Order;
            row["id_Client_FK"] = item.id_Client_FK;
            row["FIO"] = item.Client.FIO;
            row["id_Bus_FK"] = item.id_Bus_FK;
            row["Name_car"] = item.Bus.Name_car;
            row["date"] = item.date;
            row["cost"] = item.cost;
            dt.Rows.Add(row);
        }

        [WebMethod]
        public string DeleteRec(int id)
        {
            using (var rentDB= new RentBusEntities())
            {
                var orderToDelete = rentDB.Order.FirstOrDefault(o => o.id_Order == id);
                if (orderToDelete!=null)
                {
                    rentDB.Order.Remove(orderToDelete);
                    rentDB.SaveChanges();
                }
            }
            return "Ok";
        }

        [WebMethod]
        public DataTable GetClientSelectData()
        {
            using (var rentDB = new RentBusEntities())
            {
                var columns = new List<string> { "id_Client", "FIO",  "TEL" };
                using (var dt = new DataTable())
                {
                    dt.TableName = "Client";
                    foreach (var VARIABLE in columns)
                        dt.Columns.Add(VARIABLE);
                    foreach (var item in rentDB.Client)
                    {
                        var row = dt.NewRow();
                        row["id_Client"] = item.id_Client;
                        row["FIO"] = item.FIO;
                        row["TEL"] = item.TEL;
                    }
                    return dt;
                }
            }
        }

        [WebMethod]
        public DataTable GetBusSelectData()
        {
            using (var rentDB = new RentBusEntities())
            {
                var columns = new List<string> { "id_Bus", "Name_car", "VIN" };
                using (var dt = new DataTable())
                {
                    dt.TableName = "Bus";
                    foreach (var VARIABLE in columns)
                        dt.Columns.Add(VARIABLE);
                    foreach (var item in rentDB.Bus)
                    {
                        var row = dt.NewRow();
                        row["id_Bus"] = item.id_Bus;
                        row["Name_car"] = item.Name_car;
                        row["VIN"] = item.VIN;
                    }
                    return dt;
                }
            }
        }


        [WebMethod]
        public string RecCheck(string id_Client, string id_Bus, string date, string cost)
        {
            using (var rentDB = new RentBusEntities())
            {
                var flag = rentDB.Order.FirstOrDefault(o =>
                    o.id_Client_FK == int.Parse(id_Client) && o.id_Bus_FK == int.Parse(id_Bus) && DateTime.Parse(date) == o.date &&
                    o.cost == int.Parse(cost));
                return flag != null ? "1" : "0";
            }
        }
    }
}
