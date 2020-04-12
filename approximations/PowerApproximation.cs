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
    class PowerApproximation
    {
        private double _a;
        private double _b;
        private Chart _chart;

        public PowerApproximation(Chart chart)
        {
            this._chart = chart;
        }

        public bool Calculation(ref double[,] tableData, int lengthMas) // Функция вычисления 
        {
            double sumLNy = 0;
            double sumLNx2 = 0;
            double sumLNyLNx = 0;
            double sumLNx = 0;

            try
            {
                for (int i = 0; i < lengthMas; ++i)
                {
                    sumLNx += Math.Log(tableData[0, i]);
                    sumLNx2 += Math.Log(tableData[0, i]) * Math.Log(tableData[0, i]);
                    sumLNy += Math.Log(tableData[1, i]);
                    sumLNyLNx += Math.Log(tableData[0, i]) * Math.Log(tableData[1, i]);
                }

                this._a = (sumLNy * sumLNx2 - sumLNyLNx * sumLNx) / (lengthMas * sumLNx2 - sumLNx * sumLNx);
                this._a = Math.Exp(this._a);
                this._b = (lengthMas * sumLNyLNx - sumLNy * sumLNx) / (lengthMas * sumLNx2 - sumLNx * sumLNx);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DrawLineFunc(ref tableData, lengthMas);

            return true;
        }

        private void DrawLineFunc(ref double[,] tableData, int lengthMas) // ф-ия  рисования результатов на графике
        {
            // рисуем график с полученными коэф
            double[] Y = new double[lengthMas];
            double[] X = new double[lengthMas];

            for (int i = 0; i < lengthMas; i++)
            {
                X[i] = tableData[0, i];
                Y[i] = this._a * Math.Pow(tableData[0, i], this._b);
            }

            bool isSeries = false;
            int index = 0;

            // проверка, есть ли на графике легенда с Степенной аппроксимацией
            foreach (Series item in this._chart.Series)
            {
                if (item.Name == "Степенная аппроксимация")
                {
                    isSeries = true;

                    break;
                }
                index++;
            }

            if (!isSeries)
            {
                this._chart.Series.Add("Степенная аппроксимация");
                this._chart.Series[this._chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                this._chart.Series[this._chart.Series.Count - 1].BorderWidth = 4;
                this._chart.Series[this._chart.Series.Count - 1].Color = Color.Yellow;
                this._chart.Series[this._chart.Series.Count - 1].Points.DataBindXY(X, Y); // рисуем график

                return;
            }
            else
            {
                this._chart.Series[index].Points.DataBindXY(X, Y);

                return;
            }
        }
        public double getA() { return this._a; }

        public double getB() { return this._b; }
    }
}
