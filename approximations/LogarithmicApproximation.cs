﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;


namespace approximations
{
    class LogarithmicApproximation
    {
        private double _a;
        private double _b;
        private Chart _chart;

        public LogarithmicApproximation(Chart chart)
        {
            this._chart = chart;
        }

        public bool Сalculation(ref double[,] tableData, int lengthMas) // вычисление Логарифмической аппроксимации y = a*Ln(x) - b
        {
            double sumy = 0;
            double sumLnX2 = 0;
            double sumYLnX = 0;
            double sumLnx = 0;

            try
            {
                for (int i = 0; i < lengthMas; i++)
                {
                    sumy += tableData[1, i];
                    sumLnX2 += Math.Log(tableData[0, i] * tableData[0, i]);
                    sumYLnX += tableData[1, i] * Math.Log(tableData[0, i]);
                    sumLnx += Math.Log(tableData[0, i]);
                }

                this._a = (sumy * sumLnX2 - sumYLnX * sumLnx) / (lengthMas * sumLnX2 - sumLnx * sumLnx);
                this._b = (lengthMas * sumYLnX - sumy * sumLnx) / (lengthMas * sumLnX2 - sumLnx * sumLnx);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DrawLineFunc(this._a, this._b, lengthMas, ref tableData); // рисуем график с полученными результатами

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
                Y[i] = a + b * Math.Log(tableData[0, i]);
            }

            bool isSeries = false;
            int index = 0;

            // проверка, есть ли на графике легенда с Логарифмической аппроксимацией
            foreach (Series item in this._chart.Series)
            {
                if (item.Name == "Логарифмическая аппроксимация")
                {
                    isSeries = true;

                    break;
                }
                index++;
            }

            if (!isSeries)
            {
                this._chart.Series.Add("Логарифмическая аппроксимация");
                this._chart.Series[this._chart.Series.Count - 1].ChartType = SeriesChartType.Line;
                this._chart.Series[this._chart.Series.Count - 1].BorderWidth = 4;
                this._chart.Series[this._chart.Series.Count - 1].Color = Color.Orange;
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
