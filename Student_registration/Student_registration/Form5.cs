using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;

namespace Student_registration
{
    public partial class Form5 : Form
    {
        public int id = Form3.id;
        public int hours = Form3.hours;
        public string firstname = Form3.firstname;
        public string lastname = Form3.lastname;
        public string specialization = Form3.specialization;

        string connStr = "server=localhost;user=root;database=mydb;port=3306;password=password";

        public Form5()
        {
            InitializeComponent();

        }

        Microsoft.Office.Interop.Word.Application app;
        Microsoft.Office.Interop.Word.Document doc;

        object objMiss = Missing.Value;
        object TmpFile = System.IO.Path.GetTempPath()+ "registration_form.pdf";
        object FileLocation = @"C:\Users\Admin\source\repos\Student_registration\Student_registration\bin\registration_form.docx";

        private void Form5_Load(object sender, EventArgs e)
        {
            if (hours > 0)
            {
                try
                {
                    app = new Microsoft.Office.Interop.Word.Application();
                    doc = app.Documents.Open(ref FileLocation, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss, ref objMiss);

                    MySqlConnection conn = new MySqlConnection(connStr);

                    conn.Open();
                    string sql = "SELECT * FROM mydb.course WHERE ID IN(SELECT Course_ID FROM mydb.registration WHERE Student_ID = @id AND reg_Date >= '2020-10-15')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    //MySqlDataReader rdr = cmd.ExecuteReader();
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    var dt = DateTime.Now;

                    FindAndReplace("[idnumber]", id.ToString());
                    FindAndReplace("[studentname]", firstname + " " + lastname);
                    FindAndReplace("[specialization]", specialization);
                    FindAndReplace("[date]", dt.ToString("yyyy-MM-dd"));

                    Microsoft.Office.Interop.Word.Table tab = doc.Tables[1];
                    int num = 2;

                    while (rdr.Read())
                    {
                        tab.Rows.Add(ref objMiss);
                        tab.Cell(num, 1).Range.Text = rdr[0].ToString();
                        tab.Cell(num, 2).Range.Text = rdr[1].ToString();
                        tab.Cell(num, 3).Range.Text = rdr[3].ToString();
                        tab.Cell(num, 4).Range.Text = rdr[2].ToString();
                        tab.Cell(num, 5).Range.Text = rdr[5].ToString();
                        tab.Cell(num, 6).Range.Text = rdr[4].ToString();
                        tab.Cell(num, 7).Range.Text = rdr[8].ToString();
                        tab.Cell(num, 8).Range.Text = rdr[7].ToString();

                        num += 1;
                    }

                    rdr.Close();
                    conn.Close();
                    if (hours.ToString() != null)
                    {
                        FindAndReplace("[hours]", hours.ToString());
                    }

                    doc.ExportAsFixedFormat(TmpFile.ToString(), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);

                    this.pdfreader.src = TmpFile.ToString();
                    this.pdfreader.Show();


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally
                {
                    doc.Close(WdSaveOptions.wdDoNotSaveChanges, WdOriginalFormat.wdOriginalDocumentFormat, false);
                    app.Quit(WdSaveOptions.wdDoNotSaveChanges);

                }
            }
        }
        private void FindAndReplace(object FindText,object ReplaceText)
        {
            this.app.Selection.Find.Execute(ref FindText,true,true,false,false,false,true,false,1,ref ReplaceText,2,false,false,false,false);
        }

    }
}
