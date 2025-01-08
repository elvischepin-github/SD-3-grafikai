using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafikai
{
    public partial class Form2 : Form
    {
        private Form1 _form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Pavadinimas
            string newName = textBox1.Text;
            if (textBox1.Text != "")
            {
                _form1.UpdateChartName(newName);
            }

            // Vertikalius pavadinimas
            string newY = textBox2.Text;
            if (textBox2.Text != "")
            {
                _form1.UpdateChartY(newY);
            }

            // Horizontalus pavadinimas
            string newX = textBox3.Text;
            if(textBox3.Text != "")
            {
                _form1.UpdateChartX(newX);
            }

            // Spalva
            string newColor;
            if (comboBox1.SelectedIndex == 0)
            {
                newColor = "Orandzine";
                _form1.UpdateSeriesColor(newColor);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                newColor = "Violetine";
                _form1.UpdateSeriesColor(newColor);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                newColor = "Raudona";
                _form1.UpdateSeriesColor(newColor);
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                newColor = "Melyna";
                _form1.UpdateSeriesColor(newColor);
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                newColor = "Zalia";
                _form1.UpdateSeriesColor(newColor);
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                newColor = "Geltona";
                _form1.UpdateSeriesColor(newColor);
            }

            // Tipas
            string newType;
            if (comboBox2.SelectedIndex == 0)
            {
                newType = "Plotinis";
                _form1.UpdateChartType(newType);
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                newType = "Linijinis";
                _form1.UpdateChartType(newType);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                newType = "Taskelinis";
                _form1.UpdateChartType(newType);
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                newType = "Radarinis";
                _form1.UpdateChartType(newType);
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                newType = "Stulpelinis";
                _form1.UpdateChartType(newType);
            }

            // Klaidu valdymas
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Nebuvo ivesti visi pavadinimai arba nepasirinkta spalva bei grafiko tipas...", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
