using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace Service
{
    /// <summary>
    /// Сводное описание для Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        String connectionString = @"Data Source=DESKTOP-UO8LQDA;Initial Catalog=Bipit3;Integrated Security=True";
        
        [WebMethod]
        public DataTable GetRequests()
        {
            string query = "SELECT * FROM T1";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "requests";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        [WebMethod]
        public void AddRequests(DateTime date, string author, string problem)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"INSERT INTO [T1] VALUES ('{date}','{author}','{problem}')";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
        }

        [WebMethod]
        public void UpdateRequests(DateTime date, string author, string problem, int id)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"UPDATE T1 set [Дата и время] = '{date}', [Автор] = '{author}', [Описание проблемы] = '{problem}' where [Код] =  '{id}'";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
        }

        [WebMethod]
        public void DeleteRequests(int id)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"DELETE FROM T1 WHERE [Код] = '{id}'";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
        }
    }
}
