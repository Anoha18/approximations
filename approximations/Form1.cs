using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace approximations
{
    public partial class Form1 : Form
    {
        // Начальные значения, взятые из таблицы
        private double[,] tableData =
        {
            { 0.2, 0.3, 0.6, 0.8, 1.0, 1.2, 1.4, 1.6, 1.8, 2.0, 2.2, 2.4, 2.6, 2.8, 3.0, 3.2, 3.4, 3.6, 3.8, 3.9 }, // x
            { 0.1, 0.2, 0.1, 0.2, 0.3, 0.2, 0.1, 0.1, 0.1, 0.2, 0.2, 0.3, 0.3, 0.3, 0.4, 0.5, 0.4, 0.7, 0.8, 1.0 } // y
        };

        private const int lengthMas = 20;
        private int powerPolinom = 3;
        PowerPolinomForm powerPolinomForm = new PowerPolinomForm();
        KoefPolinomForm koefPolinomForm = new KoefPolinomForm();
        PolinomApproximation polinomApproximation;

        public Form1()
        {
            InitializeComponent();
            OutTableData(); // вывод данных в листбокс
            DrawTableData(); // Вывод данных на график
        }

        private void OutTableData() // ф-ия вывода данных в лист бокс
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Исходные данные: ");

            foreach (double item in tableData)
            {
                listBox1.Items.Add(item);
            }
        }

        private void DrawTableData() // функция вывода исходных данных на график
        {
            double max_x = int.MinValue;
            double min_x = int.MaxValue;
            double[] X = new double[lengthMas];
            double[] Y = new double[lengthMas];

            try
            {
                for (int i = 0; i < lengthMas; i++)
                {
                    if (tableData[0, i] > max_x) max_x = tableData[0, i];

                    if (tableData[0, i] < min_x) min_x = tableData[0, i];
                }

                // инициализация графика
                chart1.ChartAreas[0].AxisX.Minimum = min_x - 0.5;
                chart1.ChartAreas[0].AxisX.Maximum = max_x + 0.5;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = 0.5;


                for (int i = 0; i < lengthMas; i++)
                {
                    X[i] = tableData[0, i];
                    Y[i] = tableData[1, i];
                }

                if (chart1.Series.Count == 0) // Если нет колллекций
                {
                    chart1.Series.Add("Исходные данные");
                    chart1.Series[0].ChartType = SeriesChartType.Line;
                    chart1.Series[0].BorderWidth = 4;
                    chart1.Series[0].Color = Color.Red;
                }

                // рисуем ихсодные данные
                chart1.Series[0].Points.DataBindXY(X, Y);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculationLinearApproximation();
            calculationExponentialApproximation();
            calculationPowerApproximation();
            calculationPolinomApproximation();
            calculationLogarithmicApproximation();
        }

        private void calculationLinearApproximation()
        {
            LinearApproximation linearApproximation = new LinearApproximation(chart1); // переменная вычилсения линейной аппроксимации
            
            if (linearApproximation.Сalculation(ref tableData, lengthMas)) // вычисление линейной аппроксимации
            {
                linearResultA.Text = linearApproximation.getA().ToString();
                linearResultB.Text = linearApproximation.getB().ToString();
            } 
        }

        private void calculationExponentialApproximation()
        {
            ExponentialApproximation exponentialApproximation = new ExponentialApproximation(chart1);

            if (exponentialApproximation.Calculation(ref tableData, lengthMas)) // вычисление экспоненциальной аппроксимации
            {
                expResultA.Text = exponentialApproximation.getA().ToString();
                expResultB.Text = exponentialApproximation.getB().ToString();
            }
        }

        private void calculationPowerApproximation()
        {
            PowerApproximation powerApproximation = new PowerApproximation(chart1);

            if (powerApproximation.Calculation(ref tableData, lengthMas))
            {
                powerResultA.Text = powerApproximation.getA().ToString();
                powerResultB.Text = powerApproximation.getB().ToString();
            }
        }

        private void calculationPolinomApproximation()
        {
            polinomApproximation = new PolinomApproximation(chart1, this.powerPolinom);

            polinomApproximation.Calculation(ref tableData, lengthMas);
        }

        private void calculationLogarithmicApproximation()
        {
            LogarithmicApproximation logarithmicApproximation = new LogarithmicApproximation(chart1);

            if (logarithmicApproximation.Сalculation(ref tableData, lengthMas))
            {
                logResA.Text = logarithmicApproximation.getA().ToString();
                logResB.Text = logarithmicApproximation.getB().ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            powerPolinomForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!this.polinomApproximation.isSolved)
            {
                MessageBox.Show("Коэффициенты не рассчитаны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            koefPolinomForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
