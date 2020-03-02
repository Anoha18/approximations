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
            double a = 0;
            double b = 0;

            try
            {
                for (int i = 0; i < lengthMas; i++)
                {
                    sumx += tableData[0, i];
                    sumy += tableData[1, i];
                    sumx2 += tableData[0, i] * tableData[0, i];
                    sumxy += tableData[0, i] * tableData[1, i];
                }

                a = (lengthMas * sumxy - (sumx * sumy)) / (lengthMas * sumx2 - sumx * sumx); // коэф. а
                b = (sumy - a * sumx) / lengthMas; // коэф. б
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this._a = a;
            this._b = b;

            DrawLineFunc(a, b, lengthMas, ref tableData); // рисуем график с полученными результатами

            return true;
        }

        public double getA() { return this._a; }

        public double getB() { return this._b; }

        private void DrawLineFunc(double a, double b, int lengthMas, ref double[,] tableData)
        {
            // рисуем график с полученными коэф
            double[] Y = new double[lengthMas];
            double[] X = new double[lengthMas];

            for (int i = 0; i < lengthMas; i++)
            {
                X[i] = tableData[0, i];
                Y[i] = a * tableData[0, i] - b;
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
    }
}
