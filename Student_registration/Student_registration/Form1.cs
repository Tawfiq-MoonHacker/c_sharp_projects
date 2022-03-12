using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_registration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = "server=localhost;user=root;database=mydb;port=3306;password=SupermiNer@890";
                MySqlConnection conn = new MySqlConnection(connStr);
                label1.Text = "connection is succesful";
                label1.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                label1.ForeColor = Color.Red;

            }
            var newForm = new Form2();
            newForm.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new Form3();
            newForm.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newForm = new Form4();
            newForm.Show();
            Visible = false;
        }
    }
}
