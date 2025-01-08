using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Grafikai
{
    public partial class Form1 : Form
    {
        public Series grafikas1;
        Form2 form2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Width = ClientSize.Width;
            chart1.Height = ClientSize.Height - 80;
            chart1.Top = 0;
            chart1.Left = 0;
            chart1.Series.Clear();

            Random random = new Random();
            grafikas1 = new Series();
            for (int i = 0; i < 31; i++)
            {
                grafikas1.Points.Add(random.Next(12));
            }
            grafikas1.Name = "Pavadinimas";
            grafikas1.ChartType = SeriesChartType.Column;
            grafikas1.Color = Color.GreenYellow;
            chart1.ChartAreas[0].AxisX.Title = "Horizontalioji asis";
            chart1.ChartAreas[0].AxisY.Title = "Vertikalioji asis";
            chart1.Series.Add(grafikas1);
        }

        public void UpdateChartName(string newName)
        {
                grafikas1.Name = newName;
                chart1.Invalidate();
        }
        public void UpdateChartY(string newY)
        {
            chart1.ChartAreas[0].AxisY.Title = newY;
            chart1.Invalidate();
        }
        public void UpdateChartX(string newX)
        {
            chart1.ChartAreas[0].AxisX.Title = newX;
            chart1.Invalidate();
        }
        public void UpdateSeriesColor(string newColor)
        {
            if(newColor == "Orandzine")
            {
                grafikas1.Color = Color.Orange;
                chart1.Invalidate();
            }
            else if(newColor == "Violetine")
            {
                grafikas1.Color = Color.Violet;
                chart1.Invalidate();
            }
            else if(newColor == "Raudona")
            {
                grafikas1.Color = Color.Red;
                chart1.Invalidate();
            }
            else if (newColor == "Melyna")
            {
                grafikas1.Color = Color.Blue;
                chart1.Invalidate();
            }
            else if (newColor == "Zalia")
            {
                grafikas1.Color = Color.GreenYellow;
                chart1.Invalidate();
            }
            else if (newColor == "Geltona")
            {
                grafikas1.Color = Color.Gold;
                chart1.Invalidate();
            }
        }
        public void UpdateChartType(string newType)
        {
            if(newType == "Plotinis")
            {
                grafikas1.ChartType = SeriesChartType.Area;
            }
            else if (newType == "Linijinis")
            {
                grafikas1.ChartType = SeriesChartType.Line;
            }
            else if (newType == "Taskelinis")
            {
                grafikas1.ChartType = SeriesChartType.Bubble;
            }
            else if (newType == "Radarinis")
            {
                grafikas1.ChartType = SeriesChartType.Radar;
            }
            else if (newType == "Stulpelinis")
            {
                grafikas1.ChartType = SeriesChartType.Column;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Pasirinkite tekstini faila";

            MessageBox.Show("Pasirinkite tekstini faila kuriame skaiciai yra atskirti kableliu!");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string fileContent = System.IO.File.ReadAllText(filePath);
                    string[] numbersAsStrings = fileContent.Split(',');

                    List<int> numbers = new List<int>();

                    foreach (string numberStr in numbersAsStrings)
                    {
                        if (int.TryParse(numberStr.Trim(), out int number))
                        {
                            numbers.Add(number);
                        }
                    }
                    UpdateChartWithNumbers(numbers);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ivyko klaida atidarant faila: {ex.Message}", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateChartWithNumbers(List<int> numbers)
        {
            chart1.Series.Clear();
       
            for (int i = 0; i < numbers.Count; i++)
            {
                grafikas1.Points.AddXY(i + 1, numbers[i]);
            }

            chart1.Series.Add(grafikas1);
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

    }
}
