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
    // класс экспоненциальной аппроксимации
    class ExponentialApproximation
    {
        private double _a;
        private double _b;
        private Chart _chart;
        private double _deviation;
        private double[,] resultPoint;
        public bool isSolved = false;

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

            Standardeviation(lengthMas, ref tableData);
            DrawLineFunc(ref tableData, lengthMas);
            this.isSolved = true;

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

            this.resultPoint = new double[2, lengthMas];

            for (int i = 0; i < lengthMas; i++)
            {
                this.resultPoint[0, i] = X[i];
                this.resultPoint[1, i] = Y[i];
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

        public double getDeviation() { return this._deviation; }

        public ref double[,] getResultPoint() { return ref this.resultPoint; }

        // расчет среднего квадратического отклонения
        private void Standardeviation(int lengthMas, ref double[,] tableData)
        {
            this._deviation = 0;
            for (int i = 0; i < lengthMas; ++i)
            {
                this._deviation += Math.Pow(tableData[1, i] - (this._a * Math.Exp(tableData[0, i] * this._b)), 2);
            }

            this._deviation = this._deviation / (lengthMas - 1);

            this._deviation = Math.Sqrt(this._deviation);
        }
    }
}
