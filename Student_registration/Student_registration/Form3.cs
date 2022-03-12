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
    public partial class Form3 : Form
    {
        public static int id = Form2.id;
        private static ArrayList ListID = new ArrayList();

        public static string specialization;
        public string faculty;

        public static string firstname;
        public static string lastname;
        public static int hours;

        string connStr = "server=localhost;user=root;database=mydb;port=3306;password=SupermiNer@890";

        public bool timeinterfer(string s,string v)
        {
            if(s == "-" || v == "-")
            {
                return false;
            }
            string p = s.Replace(":",".");
            string firststring = p.Substring(0, p.IndexOf('-'));
            string secondstring = p.Substring(p.IndexOf('-') + 1, p.Length - (p.IndexOf('-') + 1));

            float firstnum = float.Parse(firststring);
            float secondnum = float.Parse(secondstring);

            string p1 = v.Replace(":", ".");
            string firststring1 = p1.Substring(0, p1.IndexOf('-'));
            string secondstring1 = p1.Substring(p1.IndexOf('-') + 1, p1.Length - (p1.IndexOf('-') + 1));

            float firstnum1 = float.Parse(firststring1);
            float secondnum1 = float.Parse(secondstring1);
            if(firstnum == firstnum1 && secondnum == secondnum1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int credithours()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                int credit_hours = 0;
                string sql = "SELECT co_Credit_Hours From mydb.course WHERE ID IN(SELECT Course_ID FROM mydb.registration WHERE Student_ID = @studentid)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@studentid", Int32.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@textBox3.Text", textBox3.Text);

                //MySqlDataReader rdr = cmd.ExecuteReader();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    credit_hours = credit_hours + Int32.Parse(rdr[0].ToString());
                    hours = credit_hours;
                }
                rdr.Close();
                conn.Close();
                label6.Text = "Credit Hours: " + credit_hours.ToString();
                return credit_hours;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }
        public bool maxstudents(int id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                int students = 0;
                string sql = "SELECT Course_ID From mydb.registration WHERE Course_ID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                //MySqlDataReader rdr = cmd.ExecuteReader();
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students = students + Int32.Parse(rdr[0].ToString());
                }
                rdr.Close();
                conn.Close();
                if(students > 35)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool dayinterfer(string s,string p)
        {
            if(s == "Training" || p == "Project")
            {
                return false;
            }
            if (s.Contains("/") && p.Contains("/"))
            {
                string f1 = s.Substring(0, 3);
                string s1 = s.Substring(4, 3);

                string f2 = p.Substring(0, 3);
                string s2 = p.Substring(4, 3);

                if(f1 == f2 || f1 == s2 || s1 == s2 || s1 == f2)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            if(s.Contains("/") || p.Contains("/"))
            {
                if (s.Contains("/") && !p.Contains("/") )
                {
                    string f1 = s.Substring(0, 3);
                    string s1 = s.Substring(4, 3);

                    if (s1 == p || f1 == p)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (p.Contains("/") && !s.Contains("/"))
                {
                    string f2 = p.Substring(0, 3);
                    string s2 = p.Substring(4, 3);

                    if(f2 == s || s2 == s)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else{
                if(p == s)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public Form3()
        {
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            if(id != 0)
            {
                textBox1.Text = id.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MySqlConnection conn = new MySqlConnection(connStr);
            bool submit = false;
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
                        faculty = rdr[4].ToString().Substring(0, rdr[4].ToString().IndexOf('-'));
                        specialization = rdr[4].ToString().Substring(length, faculty_specialization.Length - length);
                        textBox1.Text = rdr[0].ToString();
                        id = Int32.Parse(textBox1.Text);

                        firstname = textBox2.Text;
                        lastname = textBox3.Text;

                    }
                    rdr.Close();
                    conn.Close();
                    submit = true;
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
                        int length = rdr[4].ToString().IndexOf('-') + 1;
                        faculty = rdr[4].ToString().Substring(0, rdr[4].ToString().IndexOf('-'));
                        specialization = rdr[4].ToString().Substring(length, faculty_specialization.Length - length);
                        textBox2.Text = rdr[1].ToString();
                        textBox3.Text = rdr[2].ToString();
                        id = Int32.Parse(textBox1.Text);

                        firstname = textBox2.Text;
                        lastname = textBox3.Text;

                    }
                    rdr.Close();
                    conn.Close();
                    submit = true;
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (submit == true)
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM mydb.course WHERE ID IN(SELECT Course_ID FROM mydb.registration WHERE Student_ID = @textBox1.Text AND reg_Date >= '2020-10-15')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@textBox1.Text", textBox1.Text);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ListID.Add(rdr[0].ToString());
                        dataGridView2.Rows.Add(rdr[0].ToString(), rdr[1].ToString(), rdr[3].ToString(), rdr[2].ToString(), rdr[5].ToString(), rdr[4].ToString(), rdr[7].ToString(), rdr[8].ToString());

                    }

                    rdr.Close();
                    conn.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    conn.Open();
                    string sql = "SELECT Approval FROM mydb.registration WHERE Student_ID = @textBox1.Text";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@textBox1.Text", textBox1.Text);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    bool check_approval = false;
                    while (rdr.Read())
                    {
                        if(rdr[0].ToString() == "1")
                        {
                            check_approval = true;
                        }
                        else
                        {
                            check_approval = false;
                            break;
                        }

                    }
                    if (check_approval)
                        label7.Text = "Schedule Approved";
                    else
                        label7.Text = "Schedule Not Approved Yet";

                    rdr.Close();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    conn.Open();
                    string sql = "SELECT Name FROM mydb.instructor WHERE ID IN(SELECT Instructor_ID FROM mydb.department WHERE Name = @text)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@text", faculty);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        label8.Text = "Head Of Department " + rdr[0].ToString();

                    }

                    rdr.Close();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    conn.Open();

                    string sql = "SELECT * From mydb.course";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if(!ListID.Contains(Int32.Parse(rdr[0].ToString()))){
                            if (rdr[6].ToString().Contains(specialization) || rdr[6].ToString().Contains(faculty) || rdr[6].ToString().Contains("Elective"))
                            {
                                bool view = true;
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if (row.Cells[0].Value.ToString() == rdr[0].ToString())
                                        view = false;
                                }
                                if(view == true)
                                    dataGridView1.Rows.Add(rdr[0].ToString(), rdr[1].ToString(), rdr[3].ToString(),rdr[2].ToString(), rdr[5].ToString(), rdr[4].ToString(), rdr[7].ToString(), rdr[8].ToString());

                            }
                        }
                    }

                    rdr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                credithours();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool interfer = false;
                bool max_student = false;
                bool max_courses = false;
                if (dataGridView2.Rows.Count >= 5)
                {
                    max_courses = true;
                }
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];


                    if (maxstudents(Int32.Parse(selectedRow.Cells[0].Value.ToString())))
                    {
                        max_student = true;
                        MessageBox.Show("The hall has max students", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        //label1.Text = row.Cells[4].Value.ToString();
                        if (dayinterfer(row.Cells[5].Value.ToString(), selectedRow.Cells[5].Value.ToString()) && timeinterfer(row.Cells[4].Value.ToString(), selectedRow.Cells[4].Value.ToString()))
                        {
                            interfer = true;
                        }
                        //More code here
                    }

                    if (interfer == false && max_student == false && max_courses == false)
                    {
                        dataGridView1.Rows.RemoveAt(selectedRow.Index);

                        dataGridView2.Rows.Add(selectedRow.Cells[0].Value, selectedRow.Cells[1].Value, selectedRow.Cells[2].Value, selectedRow.Cells[3].Value, selectedRow.Cells[4].Value, selectedRow.Cells[5].Value, selectedRow.Cells[6].Value, selectedRow.Cells[7].Value);
                        ListID.Add(selectedRow.Cells[0].Value);

                        MySqlConnection conn = new MySqlConnection(connStr);
                        var dt = DateTime.Now;
                        conn.Open();

                        string sql = "INSERT INTO mydb.registration VALUES(@date,@id,@courseid,@approval)";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@date", dt.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@id", Int64.Parse(textBox1.Text));
                        cmd.Parameters.AddWithValue("@courseid", selectedRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@approval", 0);

                        //cmd.Parameters.AddWithValue("@textBox1.Text", textBox1.Text);

                        //MySqlDataReader rdr = cmd.ExecuteReader();
                        int result = cmd.ExecuteNonQuery();

                        conn.Close();
                        
                        selectedRow.Visible = false;
                        credithours();
                        if (label7.Text.Equals("Schedule Approved"))
                        {
                            try
                            {
                                label7.Text = "Schedule Not Approved";
                                conn.Open();
                                string sql1 = "UPDATE mydb.registration SET Approval = 0  WHERE Student_ID = @textBox1.Text";
                                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                                cmd1.Parameters.AddWithValue("@textBox1.Text", Int64.Parse(textBox1.Text));

                                //MySqlDataReader rdr = cmd.ExecuteReader();
                                MySqlDataReader rdr = cmd1.ExecuteReader();
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    if(interfer == true)
                    {
                        MessageBox.Show("Cannot Book at the same time", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (max_courses)
                    {
                        MessageBox.Show("registered the maximum amount of courses", "Warining", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dataGridView1.ClearSelection();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedCells.Count > 0)
                {

                    int selectedrowindex1 = dataGridView2.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex1];

                    dataGridView2.Rows.RemoveAt(selectedRow.Index);

                    dataGridView1.Rows.Add(selectedRow.Cells[0].Value, selectedRow.Cells[1].Value, selectedRow.Cells[2].Value, selectedRow.Cells[3].Value, selectedRow.Cells[4].Value, selectedRow.Cells[5].Value, selectedRow.Cells[6].Value, selectedRow.Cells[7].Value);
                                       
                    MySqlConnection conn = new MySqlConnection(connStr);
                    var dt = DateTime.Now;
                    conn.Open();

                    
                    string sql = "DELETE FROM mydb.registration WHERE course_ID = @courseid AND Student_ID = @studentid";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@courseid", selectedRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@studentid",Int64.Parse(textBox1.Text));

                    //cmd.Parameters.AddWithValue("@textBox1.Text", textBox1.Text);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    int result = cmd.ExecuteNonQuery();

                    conn.Close();
                    ListID.Remove(selectedRow.Cells[0].Value);

                    selectedRow.Visible = false;
                    credithours();

                    if(label7.Text.Equals("Schedule Approved"))
                    {
                        try
                        {
                            label7.Text = "Schedule Not Approved";
                            conn.Open();
                            string sql1 = "UPDATE mydb.registration SET Approval = 0  WHERE Student_ID = @textBox1.Text";
                            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                            cmd1.Parameters.AddWithValue("@textBox1.Text", Int64.Parse(textBox1.Text));
                            //MySqlDataReader rdr = cmd.ExecuteReader();
                            MySqlDataReader rdr = cmd1.ExecuteReader();
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                dataGridView2.ClearSelection();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var newForm = new Form1();
            newForm.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var newForm = new Form5();
            newForm.Show();
        }

    }
}
