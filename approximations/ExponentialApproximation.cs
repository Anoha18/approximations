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
    // класс экспоненциальной аппроксимации
    class ExponentialApproximation
    {
        private double _a;
        private double _b;
        private Chart _chart;
      
        public ExponentialApproximation(Chart chart)
        {
            this._chart = chart;
        }

        public bool Calculation(ref double[,] tableData, int lengthMas) // Функция вычисления 
        {
       
            double sumy = 0;
            double sumx2 = 0;
            double sumx = 0;
            double sumLNyx = 0;
            double sumLNy = 0;

            try
            {
                for (int i = 0; i < lengthMas; ++i)
                {
                    sumy += tableData[1, i];
                    sumx += tableData[0, i];
                    sumx2 += tableData[0, i] * tableData[0, i];
                    sumLNyx += Math.Log(tableData[1, i]) * tableData[0, i];
                    sumLNy += Math.Log(tableData[1, i]);
                }

                this._a = (sumLNy * sumx2 - sumLNyx * sumx) / (lengthMas * sumx2 - sumx * sumx);
                this._a = Math.Exp(this._a);
                this._b = (lengthMas * sumLNyx - sumLNy * sumx) / (lengthMas * sumx2 - sumx * sumx);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DrawLineFunc(ref tableData, lengthMas);

            return true;
        }

        private void DrawLineFunc(ref double [,] tableData, int lengthMas) // ф-ия  рисования результатов на графике
        {
            // рисуем график с полученными коэф
            double[] Y = new double[lengthMas];
            double[] X = new double[lengthMas];

            for (int i = 0; i < lengthMas; i++)
            {
                X[i] = tableData[0, i];
                Y[i] = this._a * Math.Exp(tableData[0, i] * this._b);
            }

            bool isSeries = false;
            int index = 0;

            // проверка, есть ли на графике легенда с экспоненциальной аппроксимацией
            foreach (Series item in this._chart.Series)
            {
                if (item.Name == "Экспоненциальная аппроксимация")
                {
                    isSeries = true;

                    break;
                }
                index++;
            }

            if (!isSeries)
            {
                this._chart.Series.Add("Экспоненциальная аппроксимация");
                this._chart.Series[this._chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                this._chart.Series[this._chart.Series.Count - 1].BorderWidth = 4;
                this._chart.Series[this._chart.Series.Count - 1].Color = Color.Green;
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
