using Client_Web.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client_Web
{
    public partial class TableWithAdd : System.Web.UI.Page
    {
        Service1Client sessionClient = new Service1Client("BasicHttpBinding_IService1");
        static Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/Service1/");
        BasicHttpBinding binding = new BasicHttpBinding();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            sessionClient.ConnectionInfo(binding.Name, address.Port.ToString(), address.LocalPath,
                address.ToString(), address.Scheme);
            GridView1.DataSource = sessionClient.GetData();
            GridView1.DataBind();
            DropDownList2.DataSource = sessionClient.GetComboValue();
            DropDownList2.DataTextField = "Наименование работы";
            DropDownList2.DataValueField = "Наименование работы";
            DropDownList2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var autoName = TextBox1.Text;
            var workName = DropDownList2.Text;
            var time = TextBox2.Text;
            sessionClient.NewRec(autoName, workName, time);
            Response.Redirect("/Table");
        }
    }
}