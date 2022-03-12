using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextProcessor
{
    public partial class Form1 : Form
    {
        public static int x = 0;
        public static int y = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x++;
            label1.Text = textBox1.Text;
            label3.Text = x + "";
            string textBox = textBox1.Text;
            for (int i = 0; i < textBox1.Text.Length; i++) {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
