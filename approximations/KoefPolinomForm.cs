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
    public partial class KoefPolinomForm : Form
    {
        private double[] _koef;
        public KoefPolinomForm()
        {
            InitializeComponent();
        }

        public void setKoef(double[] koef)
        {
            this._koef = new double[koef.Length];
            this._koef = koef;
            
            ShowKoef();
        }

        private void ShowKoef()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Коэффициенты: ");

            for (int i = 0; i < this._koef.Length; i++)
            {
                listBox1.Items.Add("A[" + i + "] = " + this._koef[i]);
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
