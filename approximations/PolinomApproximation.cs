using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;

namespace approximations
{
    class PolinomApproximation
    {
        private Chart _chart;
        private double[,] _matrixX; // левая матрица значений X
        private double[] _masY; // правая часть матрицы Y
        private double[] _koef; // коэф. при X
        private int _power; // степень полинома
        public bool isSolved = false;

        public PolinomApproximation(Chart chart, int power)
        {
            this._chart = chart;
            this._power = power;
            this._matrixX = new double[power, power];
            this._masY = new double[power];
            this._koef = new double[power];

            InitValue();
        }

        private void InitValue() // начальное присваивание нулей
        {
            for (int i = 0; i < this._power; i++)
            {
                for (int j = 0; j < this._power; j++)
                {
                    this._matrixX[i, j] = 0;
                }
            }

            for (int i = 0; i < this._masY.Length; i++)
            {
                this._masY[i] = 0;
            }

            for (int i = 0; i < this._koef.Length; i++)
            {
                this._koef[i] = 0;
            }
        }

        public bool Calculation(ref double[,] tableData, int lengthMas) // построение матрицы
        {
            try
            {
                for (int i = 0; i < this._masY.Length; i++)
                {
                    for (int j = 0; j < lengthMas; j++)
                    {
                        this._masY[i] += Math.Pow(tableData[0, j], i) * tableData[1, j]; // расчет сумм правой части матрицы
                    }
                }

                for (int i = 0; i < this._power; i++)
                {
                    for (int j = 0; j < this._power; j++)
                    {
                        for (int k = 0; k < lengthMas; k++)
                        {
                            this._matrixX[i, j] += Math.Pow(tableData[0, k], i + j); // расчет сумм левой части матрицы
                        }
                    }
                }


                Gaus(); // вычилсение матрицы методом гаусса

                DrawLineFunc(ref tableData, lengthMas); // отрисовка функции на графике

                this.isSolved = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            return true;
        }

        private void Gaus()
        {
            double max;
            int k, index, n;
            const double eps = 0.00001;

            k = 0;
            n = this._power;

            while (k < n)
            {
                max = Math.Abs(this._matrixX[k, k]);
                index = k;


                for (int i = k + 1; i < n; i++)
                {
                    if (Math.Abs(this._matrixX[i, k]) > max)
                    {
                        max = Math.Abs(this._matrixX[i, k]);
                        index = i;
                    }
                }

                if (max < eps)
                {
                    MessageBox.Show("Решение получить невозможно из-за нулевого столбца\n" + "index = " + index + " матрицы X", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int j = 0; j < n; j++)
                {
                    double temp1 = this._matrixX[k, j];
                    this._matrixX[k, j] = this._matrixX[index, j];
                    this._matrixX[index, j] = temp1;
                }

                double temp = this._masY[k];
                this._masY[k] = this._masY[index];
                this._masY[index] = temp;

                for (int i = k; i < n; i++)
                {
                    double temp1 = this._matrixX[i, k];
                    if (Math.Abs(temp1) < eps) continue;

                    for (int j = 0; j < n; j++)
                    {
                        this._matrixX[i, j] = this._matrixX[i, j] / temp1;
                    }

                    this._masY[i] = this._masY[i] / temp1;

                    if (i == k) continue;

                    for (int j = 0; j < n; j++)
                    {
                        this._matrixX[i, j] = this._matrixX[i, j] - this._matrixX[k, j];
                    }

                    this._masY[i] = this._masY[i] - this._masY[k];
                }
                k++;
            }

            for (k = n - 1; k >= 0; k--)
            {
                this._koef[k] = this._masY[k];
                for (int i = 0; i < k; i++)
                {
                    this._masY[i] = this._masY[i] - this._matrixX[i, k] * this._koef[k];
                }
            }

            for (int i = 0; i < this._koef.Length / 2; i++)
            {
                double temp = this._koef[i];
                this._koef[i] = this._koef[this._koef.Length - i - 1];
                this._koef[this._koef.Length - i - 1] = temp;
            }
        }

        private void DrawLineFunc(ref double[,] tableData, int lengthMas)
        {
            double[] Y = new double[lengthMas];
            double[] X = new double[lengthMas];

            for (int i = 0; i < lengthMas; i++)
            {
                X[i] = tableData[0, i];
                for (int j = 0; j < this._power; ++j)
                {
                    Y[i] += this._koef[j] * Math.Pow(tableData[0, i], this._power - j - 1);
                }
            }

            bool isSeries = false;
            int index = 0;

            // проверка, есть ли на графике легенда с аппроксимацией полиномом
            foreach (Series item in this._chart.Series)
            {
                if (item.Name == "Аппроксимация полиномом")
                {
                    isSeries = true;

                    break;
                }
                index++;
            }

            if (!isSeries)
            {
                this._chart.Series.Add("Аппроксимация полиномом");
                this._chart.Series[this._chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                this._chart.Series[this._chart.Series.Count - 1].BorderWidth = 4;
                this._chart.Series[this._chart.Series.Count - 1].Color = Color.Gray;
                this._chart.Series[this._chart.Series.Count - 1].Points.DataBindXY(X, Y); // рисуем график

                return;
            }
            else
            {
                this._chart.Series[index].Points.DataBindXY(X, Y);

                return;
            }
        }

        public double[] getKoef()
        {
            return this._koef;
        }
    }
}
