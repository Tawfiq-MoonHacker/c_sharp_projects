using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Student_registration
{
    public partial class Form4 : Form
    {
        string connStr = "server=localhost;user=root;database=mydb;port=3306;password=password";
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new Form1();
            newForm.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            if (textBox1.Text == "" && textBox3.Text != "" && textBox2.Text != "")
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT * From mydb.student WHERE(std_First_Name = @textBox2.Text and std_Last_Name = @textBox3.Text)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@textBox2.Text", textBox2.Text);
                    cmd.Parameters.AddWithValue("@textBox3.Text", textBox3.Text);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string faculty_specialization = rdr[4].ToString();
                        int length = rdr[4].ToString().IndexOf('-') + 1;
                        textBox1.Text = rdr[0].ToString();
                    }
                    rdr.Close();
                    conn.Close();
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                }
                catch
                {
                    MessageBox.Show("Enter ID Number or Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (textBox2.Text == "" && textBox3.Text == "" && textBox1.Text != "")
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT * From mydb.student WHERE ID = @textBox1.Text";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@textBox1.Text", textBox1.Text);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string faculty_specialization = rdr[4].ToString();
                        textBox2.Text = rdr[1].ToString();
                        textBox3.Text = rdr[2].ToString();
                    }
                    rdr.Close();
                    conn.Close();
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "DELETE * From mydb.student WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",textBox1.Text);

                //MySqlDataReader rdr = cmd.ExecuteReader();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string faculty_specialization = rdr[4].ToString();
                    int length = rdr[4].ToString().IndexOf('-') + 1;
                    textBox1.Text = rdr[0].ToString();
                }
                rdr.Close();
                conn.Close();
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Cannot Withdrawal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
