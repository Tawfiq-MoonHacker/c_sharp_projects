using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Build.Framework.XamlTypes;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using System.Windows.Forms.DataVisualization.Charting;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace ResturanMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double price;
        public double tax = 0.16;
        public double coupon = 1.0;
        public int calories;
        public void ChangeLabels()
        {
            label3.Text = "" + price;
            label4.Text = "" + price * tax;
            label5.Text = "" + price * (1 + tax) * coupon;
            label11.Text = "" + calories;
        }
        public void ClearChart()
        {
            chart1.Titles.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == "Hamburger")
            {
                pictureBox1.Image = ResturanMenu.Properties.Resources.Hamburger;
                price = 4.5;
                calories = 295;
                ChangeLabels();

                ClearChart();

                chart1.Titles.Add("Hamburger Nutrition (100 Grams)");
                chart1.Series["Series1"].IsValueShownAsLabel = true;

                chart1.Series["Series1"].Points.AddXY("Potasium", "0.226");
                chart1.Series["Series1"].Points.AddXY("Sodium", "0.414");
                chart1.Series["Series1"].Points.AddXY("Cholestrol", "0.047");
                chart1.Series["Series1"].Points.AddXY("Fat", "14");
                chart1.Series["Series1"].Points.AddXY("Carbohydrate", "24");
                chart1.Series["Series1"].Points.AddXY("Protein", "17");

            }
            if(comboBox1.SelectedItem == "Crispy Fried Chicken")
            {
                pictureBox1.Image = ResturanMenu.Properties.Resources.crispyfriedchicken;
                price = 3.5;
                calories = 300;
                ChangeLabels();

                ClearChart();

                chart1.Titles.Add("Crispy Fried Chicken Nutrition per 100 Grams");
                chart1.Series["Series1"].IsValueShownAsLabel = true;

                chart1.Series["Series1"].Points.AddXY("Sodium", "4.5");
                chart1.Series["Series1"].Points.AddXY("Iron", "0.0036");
                chart1.Series["Series1"].Points.AddXY("Fat", "14");
                chart1.Series["Series1"].Points.AddXY("Carbohydrate", "70");
                chart1.Series["Series1"].Points.AddXY("Protein", "10");

            }
            if(comboBox1.SelectedItem == "Pizza")
            {
                pictureBox1.Image = ResturanMenu.Properties.Resources.Pizaa;
                price = 7.99;
                calories = 460;
                ChangeLabels();

                ClearChart();

                chart1.Titles.Add("One large slice Nutrition (167 grams)");
                chart1.Series["Series1"].IsValueShownAsLabel = true;

                chart1.Series["Series1"].Points.AddXY("Sugar", "1");
                chart1.Series["Series1"].Points.AddXY("Sodium", "0.9");
                chart1.Series["Series1"].Points.AddXY("Fat", "26");
                chart1.Series["Series1"].Points.AddXY("Carbs", "37");
                

            }
            if(comboBox1.SelectedItem == "Steak")
            {
                pictureBox1.Image = ResturanMenu.Properties.Resources.Steak;
                price = 8.00;
                calories = 179;
                ChangeLabels();

                ClearChart();

                chart1.Titles.Add("Steak Nutrition (85 Grams)");
                chart1.Series["Series1"].IsValueShownAsLabel = true;

                chart1.Series["Series1"].Points.AddXY("Sodium", "0.049");
                chart1.Series["Series1"].Points.AddXY("Fat", "7.6");
                chart1.Series["Series1"].Points.AddXY("Protein", "26");

            }
            if(comboBox1.SelectedItem == "Chocolate Chip Cookie")
            {
                pictureBox1.Image = ResturanMenu.Properties.Resources.ChocolateChip;
                price = 1.99;
                calories = 148;
                ChangeLabels();

                ClearChart();

                chart1.Titles.Add("Cookies Nutrition (30 Grams)");
                chart1.Series["Series1"].IsValueShownAsLabel = true;

                chart1.Series["Series1"].Points.AddXY("Potasium", "0.051");
                chart1.Series["Series1"].Points.AddXY("Sodium", "0.093");;
                chart1.Series["Series1"].Points.AddXY("Fat", "7.4");
                chart1.Series["Series1"].Points.AddXY("Carbohydrate", "20");
                chart1.Series["Series1"].Points.AddXY("Protein", "1.5");
                chart1.Series["Series1"].Points.AddXY("Caffeine", "0.0033");


            }
            if(comboBox1.SelectedItem == "Taco")
            {
                pictureBox1.Image = ResturanMenu.Properties.Resources.Taco;
                price = 3.99;
                calories = 210;
                ChangeLabels();

                ClearChart();

                chart1.Titles.Add("Taco Nutrition (102 Grams)");
                chart1.Series["Series1"].IsValueShownAsLabel = true;

                chart1.Series["Series1"].Points.AddXY("Potasium", "0.164");
                chart1.Series["Series1"].Points.AddXY("Sodium", "0.571");
                chart1.Series["Series1"].Points.AddXY("Cholestrol", "0.026");
                chart1.Series["Series1"].Points.AddXY("Fat", "9.9");
                chart1.Series["Series1"].Points.AddXY("Carbohydrate", "21");
                chart1.Series["Series1"].Points.AddXY("Protein", "9.4");

            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Taco")
            {
                MessageBox.Show("A taco is a traditional Mexican dish consisting of a small hand-sized corn or wheat tortilla topped with a filling. The tortilla is then folded around the filling and eaten by hand.", "Taco Ingredients", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            if (comboBox1.SelectedItem == "Chocolate Chip Cookie")
            {
                MessageBox.Show("A chocolate chip cookie is a drop cookie that originated in the United States and features chocolate chips or chocolate morsels as its distinguishing ingredient. Circa 1938, Ruth Graves Wakefield added chopped up bits from a Nestlé semi-sweet chocolate bar into a cookie.", "Cookie Ingredients", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            if (comboBox1.SelectedItem == "Pizza")
            {
                MessageBox.Show("Pizza is a savory dish of Italian origin, consisting of a usually round, flattened base of leavened wheat-based dough topped with tomatoes, cheese, and often various other ingredients baked at a high temperature, traditionally in a wood-fired oven. A small pizza is sometimes called a pizzetta.", "Pizza Ingredients", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            if (comboBox1.SelectedItem == "Hamburger")
            {
                MessageBox.Show("A hamburger is a sandwich consisting of one or more cooked patties of ground meat, usually beef, placed inside a sliced bread roll or bun. The patty may be pan fried, grilled, smoked or flame broiled.", "Hamburger Ingredients", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            if (comboBox1.SelectedItem == "Crispy Fried Chicken")
            {
                MessageBox.Show("Crispy fried chicken is a standard dish in the Cantonese cuisine of southern China and Hong Kong. The chicken is fried in such a way that the skin is extremely crunchy, but the white meat is relatively soft.", "Crispy Fried Chicken Ingredients", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "25%")
            {
                coupon = 0.75;
                ChangeLabels();
            }
            if (comboBox2.SelectedItem == "50%")
            {
                coupon = 0.50;
                ChangeLabels();
            }
            if (comboBox2.SelectedItem == "75%")
            {
                coupon = 0.25;
                ChangeLabels();
            }
            if (comboBox2.SelectedItem == "100%")
            {
                coupon = 0.0;
                ChangeLabels();
            }
            if(comboBox2.SelectedItem == "None")
            {
                coupon = 1.0;
                ChangeLabels();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
