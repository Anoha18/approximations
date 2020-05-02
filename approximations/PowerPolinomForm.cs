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
    public partial class PowerPolinomForm : Form
    {
        public PowerPolinomForm()
        {
            InitializeComponent();
        }

        public void setPower(int power)
        {
            this.Power = power;
            textBox1.Text = this.Power.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int power = Convert.ToInt32(textBox1.Text);
            if (power < 0)
            {
                MessageBox.Show("Степень полинома не может быть отрицательной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Power = power;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public int Power { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
