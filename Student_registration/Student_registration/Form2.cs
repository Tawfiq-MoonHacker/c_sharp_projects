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
using System.Collections;

namespace Student_registration
{
    public partial class Form2 : Form
    {
        public static int id;
        string connStr = "server=localhost;user=root;database=mydb;port=3306;password=password";
        public Form2()
        {

            InitializeComponent();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                string sql = "SELECT MAX(ID) FROM mydb.student";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    id = Int32.Parse(rdr[0].ToString()) + 1;
                    label1.Text = id.ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new Form1();
            newForm.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool submit = true;
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                string sql = "SELECT * From mydb.student WHERE((std_First_Name = @textBox1.Text and std_Last_Name = @textBox2.Text))";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@textBox1.Text", textBox1.Text);
                cmd.Parameters.AddWithValue("@textBox2.Text", textBox2.Text);

                //MySqlDataReader rdr = cmd.ExecuteReader();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr[0] != null)
                    {
                        submit = false;
                        MessageBox.Show("The Student Exist", "Error", MessageBoxButtons.OK);
                    }
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();

            string specialization = this.comboBox1.GetItemText(this.comboBox1.SelectedItem).ToString() + '-' + this.comboBox2.GetItemText(this.comboBox2.SelectedItem).ToString();

            if (submit)
            {
                try
                {
                    conn.Open();

                    string sql = "INSERT INTO mydb.student VALUES(@id,@texbox1,@textBox2.Text,@textBox3.Text,@spcialization,@gpa)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    cmd.Parameters.AddWithValue("@texbox1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@textBox2.Text", textBox2.Text);
                    DateTime iDate;
                    iDate = dateTimePicker1.Value;
                    string formatted = iDate.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@textbox3.Text", formatted);

                    cmd.Parameters.AddWithValue("@gpa", int.Parse(textBox6.Text));
                    cmd.Parameters.AddWithValue("@spcialization", specialization.ToString());

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
                var newForm = new Form3();
                newForm.Show();
                Visible = false;
            }
        }
    }
}
