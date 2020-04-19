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
        private double[,] _matrixX;
        private double[] _masY;
        private double[] _koef;
        private int _power;

        public PolinomApproximation(Chart chart, int power)
        {
            this._chart = chart;
            this._power = power;
            this._matrixX = new double[power, power];
            this._masY = new double[power];
            this._koef = new double[power];

            InitValue();
        }

        private void InitValue()
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

        public bool Calculation(ref double[,] tableData, int lengthMas)
        {
            for (int i = 0; i < this._masY.Length; i++)
            {
                for (int j = 0; j < lengthMas; j++)
                {
                    this._masY[i] += Math.Pow(tableData[0, j], i) * tableData[1, j];
                }
            }

            for (int i = 0; i < this._power; i++)
            {
                for (int j = 0; j < this._power; j++)
                {
                    for (int k = 0; k < lengthMas; k++)
                    {
                        this._matrixX[i, j] += Math.Pow(tableData[0, k], i + j);
                    }
                }
            }


            Gaus();

            Console.WriteLine("1111");
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
        }
    }
}
