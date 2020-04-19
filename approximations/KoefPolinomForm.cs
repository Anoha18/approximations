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
        }
    }
}
