using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_4_CSharp
{
    public partial class Add1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var s = new ServiceReference1.WebService1SoapClient();
                DropDownList3.DataSource = s.GetClientSelectData();
                DropDownList3.DataTextField = "FIO";
                DropDownList3.DataValueField = "id_Client";
                DropDownList3.DataBind();
                DropDownList2.DataSource = s.GetBusSelectData();
                DropDownList2.DataTextField = "Name_car";
                DropDownList2.DataValueField = "id_Bus";
                DropDownList2.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        { 
            var s = new ServiceReference1.WebService1SoapClient();
            var id_Client = DropDownList3.Text;
            var id_Bus = DropDownList2.Text;
            var date = this.dateXEP.Text;
            var cost = this.cost.Text;
            var check = s.RecCheck(id_Client, id_Bus, date, cost);
            if (check == "1")
            {
                Label2.Visible = true;
            }
            else
            {
                Label1.Text = s.InsertMethod(id_Client, id_Bus, date, cost);
                Label1.Visible = true;
                Response.Redirect("/Table");
            }
        }

        protected void dateEx_TextChanged(object sender, EventArgs e)
        {
          
        }

        protected void cost_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}