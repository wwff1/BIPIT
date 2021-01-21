using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_4_CSharp
{
    public partial class Table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            var s = new ServiceReference1.WebService1SoapClient();
            GridView1.DataSource = s.GetData(null, null);
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var s = new ServiceReference1.WebService1SoapClient();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
                if (cb != null && cb.Checked)
                {
                    int customAttr1 = int.Parse(cb.Attributes["data-Value"]);
                    s.DeleteRec(customAttr1);
                }
            }

            Response.Redirect("/Table");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(TextBox1.Text) < DateTime.Parse(TextBox2.Text))
            {
                var s = new ServiceReference1.WebService1SoapClient();
                GridView1.DataSource = s.GetData(TextBox1.Text, TextBox2.Text);
                GridView1.DataBind();
            }
                       

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(TextBox1.Text) > DateTime.Parse(TextBox2.Text))
            {
                Label1.Text = "Невозможный формат даты";
                Label1.Visible = true;
            }
            else Label1.Visible = false;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}