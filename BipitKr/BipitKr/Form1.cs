using BipitKr.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BipitKr
{
    public partial class Form1 : Form
    {
        ServiceSoapClient service = new ServiceReference1.ServiceSoapClient();
        int id;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = service.GetRequests();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            string author = textBox1.Text;
            string problem = richTextBox1.Text;
            service.AddRequests(date, author, problem);
            dataGridView1.DataSource = service.GetRequests();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[index].Cells[1].Value);
            textBox1.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            string author = textBox1.Text;
            string problem = richTextBox1.Text;
            service.UpdateRequests(date, author, problem, id);
            dataGridView1.DataSource = service.GetRequests();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            service.DeleteRequests(Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value));
            dataGridView1.DataSource = service.GetRequests();
        }
    }
}
