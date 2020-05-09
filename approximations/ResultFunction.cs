using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace approximations
{
    public partial class ResultFunction : Form
    {
        private double[,] _tableData;
        private double[,] _linearResult;
        private double[,] _logResult;
        private double[,] _powerResult;
        private double[,] _expResult;
        private double[,] _polinomResult;
        private int _lengthMas;

        public ResultFunction()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public void setLengthMas(int lengthMas)
        {
            this._lengthMas = lengthMas;
        }

        public void setTableData(double[,] tableData)
        {
            this._tableData = tableData;

            this.tableData.ColumnCount = this._lengthMas;
            for (int i = 0; i < this._lengthMas; i++)
            {
                this.tableData.Columns[i].Name = (i + 1).ToString();
            }

            for (int i = 0; i < this._tableData.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.tableData);

                for (int j = 0; j < this._tableData.GetLength(1); j++)
                {
                    row.Cells[j].Value = this._tableData[i, j];
                }

                this.tableData.Rows.Add(row);
            }
        }

        public void setLinearResult(double[,] linearResult)
        {
            this._linearResult = linearResult;

            this.linearResult.ColumnCount = this._lengthMas;
            for (int i = 0; i < this._lengthMas; i++)
            {
                this.linearResult.Columns[i].Name = (i + 1).ToString();
            }

            for (int i = 0; i < this._linearResult.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.linearResult);

                for (int j = 0; j < this._linearResult.GetLength(1); j++)
                {
                    row.Cells[j].Value = this._linearResult[i, j];
                }

                this.linearResult.Rows.Add(row);
            }
        }

        public void setLogResult(double[,] logResult)
        {
            this._logResult = logResult;

            this.logResult.ColumnCount = this._lengthMas;
            for (int i = 0; i < this._lengthMas; i++)
            {
                this.logResult.Columns[i].Name = (i + 1).ToString();
            }

            for (int i = 0; i < this._logResult.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.logResult);

                for (int j = 0; j < this._logResult.GetLength(1); j++)
                {
                    row.Cells[j].Value = this._logResult[i, j];
                }

                this.logResult.Rows.Add(row);
            }
        }

        public void setPowerResult(double[,] powerResult)
        {
            this._powerResult = powerResult;

            this.powerResult.ColumnCount = this._lengthMas;
            for (int i = 0; i < this._lengthMas; i++)
            {
                this.powerResult.Columns[i].Name = (i + 1).ToString();
            }

            for (int i = 0; i < this._powerResult.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.powerResult);

                for (int j = 0; j < this._powerResult.GetLength(1); j++)
                {
                    row.Cells[j].Value = this._powerResult[i, j];
                }

                this.powerResult.Rows.Add(row);
            }
        }

        public void setExpResult(double[,] expResult)
        {
            this._expResult = expResult;

            this.expResult.ColumnCount = this._lengthMas;
            for (int i = 0; i < this._lengthMas; i++)
            {
                this.expResult.Columns[i].Name = (i + 1).ToString();
            }

            for (int i = 0; i < this._expResult.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.expResult);

                for (int j = 0; j < this._expResult.GetLength(1); j++)
                {
                    row.Cells[j].Value = this._expResult[i, j];
                }

                this.expResult.Rows.Add(row);
            }
        }

        public void setPolinomResult(double[,] polinomResult)
        {
            this._polinomResult = polinomResult;

            this.polinomResult.ColumnCount = this._lengthMas;
            for (int i = 0; i < this._lengthMas; i++)
            {
                this.polinomResult.Columns[i].Name = (i + 1).ToString();
            }

            for (int i = 0; i < this._polinomResult.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.polinomResult);

                for (int j = 0; j < this._polinomResult.GetLength(1); j++)
                {
                    row.Cells[j].Value = this._polinomResult[i, j];
                }

                this.polinomResult.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
