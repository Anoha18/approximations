using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace approximations
{
    class LinearApproximation
    {
        private double _a;
        private double _b;
        private Chart _chart;
        private double _deviation;
        private double[,] resultPoint;
        public bool isSolved = false;

        public LinearApproximation(Chart chart)
        {
            this._chart = chart;
        }

        public bool Сalculation(ref double[,] tableData, int lengthMas) // вычисление линейной аппроксимации y = a*x - b
        {
            double sumxy = 0;
            double sumx = 0;
            double sumx2 = 0;
            double sumy = 0;

            try
            {
                for (int i = 0; i < lengthMas; ++i)
                {
                    sumx += tableData[0, i];
                    sumy += tableData[1, i];
                    sumx2 += tableData[0, i] * tableData[0, i];
                    sumxy += tableData[0, i] * tableData[1, i];
                }

                this._a = (lengthMas * sumxy - (sumx * sumy)) / (lengthMas * sumx2 - sumx * sumx); // коэф. а
                this._b = (sumy - this._a * sumx) / lengthMas; // коэф. б
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Standardeviation(lengthMas, ref tableData); // расчет среднего квадратического отклонения
            DrawLineFunc(this._a, this._b, lengthMas, ref tableData); // рисуем график с полученными результатами
            this.isSolved = true;

            return true;
        }

        public double getA() { return this._a; }

        public double getB() { return this._b; }

        public double getDeviation() { return this._deviation; }

        public ref double[,] getResultPoint() { return ref this.resultPoint; }

        private void DrawLineFunc(double a, double b, int lengthMas, ref double[,] tableData)
        {
            // рисуем график с полученными коэф
            double[] Y = new double[lengthMas];
            double[] X = new double[lengthMas];

            for (int i = 0; i < lengthMas; i++)
            {
                X[i] = tableData[0, i];
                Y[i] = a * tableData[0, i] + b;
            }

            this.resultPoint = new double[2, lengthMas];

            for (int i = 0; i < lengthMas; i++)
            {
                this.resultPoint[0, i] = X[i];
                this.resultPoint[1, i] = Y[i];
            }

            bool isSeries = false;
            int index = 0;

            // проверка, есть ли на графике легенда с линейной аппроксимацией
            foreach (Series item in this._chart.Series)
            {
                if (item.Name == "Линейная аппроксимация")
                {
                    isSeries = true;

                    break;
                }
                index++;
            }

            if (!isSeries)
            {
                this._chart.Series.Add("Линейная аппроксимация");
                this._chart.Series[this._chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                this._chart.Series[this._chart.Series.Count - 1].BorderWidth = 4;
                this._chart.Series[this._chart.Series.Count - 1].Color = Color.Blue;
                this._chart.Series[this._chart.Series.Count - 1].Points.DataBindXY(X, Y); // рисуем график

                return;
            }
            else
            {
                this._chart.Series[index].Points.DataBindXY(X, Y);

                return;
            }
        }

        // расчет среднего квадратического отклонения
        private void Standardeviation(int lengthMas, ref double[,] tableData)
        {
            this._deviation = 0;
            for (int i = 0; i < lengthMas; i++)
            {
                this._deviation += Math.Pow(tableData[1, i] - (this._a * tableData[0, i] + this._b), 2);
            }

            this._deviation = this._deviation / (lengthMas - 1);

            this._deviation = Math.Sqrt(this._deviation);
        }
    }
}
