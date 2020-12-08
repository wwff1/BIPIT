using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Client.ServiceReference1;


namespace Client
{
    public partial class Form1 : Form
    {
        Service1Client sessionClient = new Service1Client("NetTcpBinding_IService1");
        static Uri address = new Uri("net.tcp://localhost:9733/Design_Time_Addresses/Service1/");
        NetTcpBinding binding = new NetTcpBinding();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = sessionClient.GetComboValue();
            Table();
            comboBox1.DisplayMember = "Наименование работы";
            comboBox1.ValueMember = "Наименование работы";
        }

        public void Table()
        {
            dataGridView1.DataSource = sessionClient.GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sessionClient.NewRec(textBox1.Text, comboBox1.Text, textBox2.Text);
            Table();
            sessionClient.ConnectionInfo(binding.Name, address.Port.ToString(), address.LocalPath,
                    address.ToString(), address.Scheme);
        }
    }
}
