using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        string path = @"Data Source=Bipit337.mssql.somee.com;Initial Catalog=Bipit337;User Id=bipit1_SQLLogin_4;Password=9j9dxyk2f2";
        public void DoWork()
        {

        }

        public DataTable GetData()
        {
            string query = "SELECT * FROM Service";
            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Order";
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable GetComboValue()
        {
            string query = "SELECT * FROM Work";
            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(query);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Work";
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void NewRec(string auto, string work, string date)
        {
            string query = $"INSERT INTO Service ([Наименование авто], [Наименование работы], [Стоимость], [Стандартное время работы], [Фактическое время работы])" +
                $"VALUES ('{auto}', '{work}','', (select [Стандартное время работы] from Work where [Наименование работы] = '{work}'), '{date}')";
            string query1 = @"update Service 
                            set Стоимость = [Фактическое время работы] * (Work.Стоимость/Work.[Стандартное время работы])
                            FROM Service, Work where Work.[Наименование работы]=Service.[Наименование работы]";
            using (SqlConnection con = new SqlConnection(path))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.ExecuteNonQuery();
            }
        }
    }
}
