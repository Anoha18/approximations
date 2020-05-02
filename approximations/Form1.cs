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
        PolinomApproximation polinomApproximation;

        public Form1()
        {
            InitializeComponent();
            polinomPower.Text = this.powerPolinom.ToString();
            OutTableData(); // вывод данных в листбокс
            DrawTableData(); // Вывод данных на график
        }

        private void OutTableData() // ф-ия вывода данных в лист бокс
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Исходные данные: ");

            char prefix = 'X';
            for (int i = 0; i < 2; i++)
            {
                listBox1.Items.Add("-----------------------------");
                for (int j = 0; j < lengthMas; j++)
                {
                    listBox1.Items.Add(prefix.ToString() + '[' + (j + 1) + "] = " + tableData[i, j]);
                }

                prefix = 'Y';
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
            if (checkLinear.Checked)
            {
                LinearApproximation linearApproximation = new LinearApproximation(chart1); // переменная вычилсения линейной аппроксимации
            
                if (linearApproximation.Сalculation(ref tableData, lengthMas)) // вычисление линейной аппроксимации
                {
                    linearResultA.Text = linearApproximation.getA().ToString();
                    linearResultB.Text = linearApproximation.getB().ToString();
                    deviationLinear.Text = linearApproximation.getDeviation().ToString();
                }

                return;
            }

            linearResultA.Text = "-";
            linearResultB.Text = "-";
            deviationLinear.Text = "-";
            DeleteSeries("Линейная аппроксимация");
        }

        private void calculationExponentialApproximation()
        {
            if (checkExp.Checked)
            {
                ExponentialApproximation exponentialApproximation = new ExponentialApproximation(chart1);

                if (exponentialApproximation.Calculation(ref tableData, lengthMas)) // вычисление экспоненциальной аппроксимации
                {
                    expResultA.Text = exponentialApproximation.getA().ToString();
                    expResultB.Text = exponentialApproximation.getB().ToString();
                    deviationExp.Text = exponentialApproximation.getDeviation().ToString();
                }

                return;
            }

            expResultA.Text = "-";
            expResultB.Text = "-";
            deviationExp.Text = "-";
            DeleteSeries("Экспоненциальная аппроксимация");
        }

        private void calculationPowerApproximation()
        {
            if (checkPower.Checked)
            {
                PowerApproximation powerApproximation = new PowerApproximation(chart1);

                if (powerApproximation.Calculation(ref tableData, lengthMas))
                {
                    powerResultA.Text = powerApproximation.getA().ToString();
                    powerResultB.Text = powerApproximation.getB().ToString();
                    deviationPower.Text = powerApproximation.getDeviation().ToString();
                }

                return;
            }

            powerResultA.Text = "-";
            powerResultB.Text = "-";
            deviationPower.Text = "-";

            DeleteSeries("Степенная аппроксимация");
        }

        private void calculationPolinomApproximation()
        {
            if (checkPolinom.Checked)
            {
                polinomApproximation = new PolinomApproximation(chart1, this.powerPolinom);

                polinomApproximation.Calculation(ref tableData, lengthMas);
                deviationPolinom.Text = polinomApproximation.getDeviation().ToString();

                return;
            }

            deviationPolinom.Text = "-";
            DeleteSeries("Аппроксимация полиномом");
        }

        private void calculationLogarithmicApproximation()
        {
            if (checkLog.Checked)
            {
                LogarithmicApproximation logarithmicApproximation = new LogarithmicApproximation(chart1);

                if (logarithmicApproximation.Сalculation(ref tableData, lengthMas))
                {
                    logResA.Text = logarithmicApproximation.getA().ToString();
                    logResB.Text = logarithmicApproximation.getB().ToString();
                    deviationLog.Text = logarithmicApproximation.getDeviation().ToString();
                }

                return;
            }

            logResA.Text = "-";
            logResB.Text = "-";
            deviationLog.Text = "-";
            DeleteSeries("Логарифмическая аппроксимация");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PowerPolinomForm powerPolinomForm = new PowerPolinomForm();
            using (powerPolinomForm)
            {
                powerPolinomForm.setPower(this.powerPolinom);
                DialogResult result = powerPolinomForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.powerPolinom = powerPolinomForm.Power;
                    polinomPower.Text = this.powerPolinom.ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KoefPolinomForm koefPolinomForm = new KoefPolinomForm();
            if (this.polinomApproximation is null || !this.polinomApproximation.isSolved || !checkPolinom.Checked)
            {
                MessageBox.Show("Коэффициенты не рассчитаны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            koefPolinomForm.setKoef(this.polinomApproximation.getKoef());
            koefPolinomForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        public void setPowerPolinom(int power)
        {
            this.powerPolinom = power;
        }

        private void DeleteSeries(string seriesName)
        {
            bool isSeries = false;
            Series series = new Series();
            int index = 0;

            foreach (Series item in chart1.Series)
            {
                if (item.Name == seriesName)
                {
                    isSeries = true;
                    series = item;

                    break;
                }
                index++;
            }

            if (isSeries)
            {
                chart1.Series.Remove(series);
            }
        }
    }
}
