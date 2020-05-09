namespace approximations
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linearResultA = new System.Windows.Forms.Label();
            this.linearResultB = new System.Windows.Forms.Label();
            this.expResultB = new System.Windows.Forms.Label();
            this.expResultA = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.powerResultB = new System.Windows.Forms.Label();
            this.powerResultA = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.logResB = new System.Windows.Forms.Label();
            this.logResA = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deviationLinear = new System.Windows.Forms.Label();
            this.deviationExp = new System.Windows.Forms.Label();
            this.deviationPower = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.deviationLog = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.deviationPolinom = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.polinomPower = new System.Windows.Forms.Label();
            this.checkLinear = new System.Windows.Forms.CheckBox();
            this.checkExp = new System.Windows.Forms.CheckBox();
            this.checkPower = new System.Windows.Forms.CheckBox();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.checkPolinom = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(358, 356);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 908);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 910);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 53);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(418, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1362, 949);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Линейная аппроксимация: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "A = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "B = ";
            // 
            // linearResultA
            // 
            this.linearResultA.AutoSize = true;
            this.linearResultA.Location = new System.Drawing.Point(71, 397);
            this.linearResultA.Name = "linearResultA";
            this.linearResultA.Size = new System.Drawing.Size(21, 17);
            this.linearResultA.TabIndex = 7;
            this.linearResultA.Text = " - ";
            // 
            // linearResultB
            // 
            this.linearResultB.AutoSize = true;
            this.linearResultB.Location = new System.Drawing.Point(71, 414);
            this.linearResultB.Name = "linearResultB";
            this.linearResultB.Size = new System.Drawing.Size(21, 17);
            this.linearResultB.TabIndex = 8;
            this.linearResultB.Text = " - ";
            // 
            // expResultB
            // 
            this.expResultB.AutoSize = true;
            this.expResultB.Location = new System.Drawing.Point(68, 497);
            this.expResultB.Name = "expResultB";
            this.expResultB.Size = new System.Drawing.Size(21, 17);
            this.expResultB.TabIndex = 13;
            this.expResultB.Text = " - ";
            // 
            // expResultA
            // 
            this.expResultA.AutoSize = true;
            this.expResultA.Location = new System.Drawing.Point(68, 480);
            this.expResultA.Name = "expResultA";
            this.expResultA.Size = new System.Drawing.Size(21, 17);
            this.expResultA.TabIndex = 12;
            this.expResultA.Text = " - ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "B = ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "A = ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 463);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Экспоненциальная аппроксимация: ";
            // 
            // powerResultB
            // 
            this.powerResultB.AutoSize = true;
            this.powerResultB.Location = new System.Drawing.Point(71, 580);
            this.powerResultB.Name = "powerResultB";
            this.powerResultB.Size = new System.Drawing.Size(21, 17);
            this.powerResultB.TabIndex = 18;
            this.powerResultB.Text = " - ";
            // 
            // powerResultA
            // 
            this.powerResultA.AutoSize = true;
            this.powerResultA.Location = new System.Drawing.Point(71, 563);
            this.powerResultA.Name = "powerResultA";
            this.powerResultA.Size = new System.Drawing.Size(21, 17);
            this.powerResultA.TabIndex = 17;
            this.powerResultA.Text = " - ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 580);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "B = ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 563);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "A = ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 546);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "Степенная аппроксимация: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 707);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(268, 17);
            this.label14.TabIndex = 19;
            this.label14.Text = "Аппроксимация полиномом n степени: ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 771);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 38);
            this.button3.TabIndex = 20;
            this.button3.Text = "Коэффициенты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(160, 771);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 38);
            this.button4.TabIndex = 21;
            this.button4.Text = "Степень";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // logResB
            // 
            this.logResB.AutoSize = true;
            this.logResB.Location = new System.Drawing.Point(68, 660);
            this.logResB.Name = "logResB";
            this.logResB.Size = new System.Drawing.Size(21, 17);
            this.logResB.TabIndex = 26;
            this.logResB.Text = " - ";
            // 
            // logResA
            // 
            this.logResA.AutoSize = true;
            this.logResA.Location = new System.Drawing.Point(68, 643);
            this.logResA.Name = "logResA";
            this.logResA.Size = new System.Drawing.Size(21, 17);
            this.logResA.TabIndex = 25;
            this.logResA.Text = " - ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 660);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "B = ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 643);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "A = ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 626);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(244, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "Логарифмическая аппроксимация: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ср. кв. отклонение = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Ср. кв. отклонение = ";
            // 
            // deviationLinear
            // 
            this.deviationLinear.AutoSize = true;
            this.deviationLinear.Location = new System.Drawing.Point(187, 431);
            this.deviationLinear.Name = "deviationLinear";
            this.deviationLinear.Size = new System.Drawing.Size(13, 17);
            this.deviationLinear.TabIndex = 29;
            this.deviationLinear.Text = "-";
            // 
            // deviationExp
            // 
            this.deviationExp.AutoSize = true;
            this.deviationExp.Location = new System.Drawing.Point(181, 514);
            this.deviationExp.Name = "deviationExp";
            this.deviationExp.Size = new System.Drawing.Size(13, 17);
            this.deviationExp.TabIndex = 30;
            this.deviationExp.Text = "-";
            // 
            // deviationPower
            // 
            this.deviationPower.AutoSize = true;
            this.deviationPower.Location = new System.Drawing.Point(184, 597);
            this.deviationPower.Name = "deviationPower";
            this.deviationPower.Size = new System.Drawing.Size(13, 17);
            this.deviationPower.TabIndex = 32;
            this.deviationPower.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(29, 597);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(149, 17);
            this.label17.TabIndex = 31;
            this.label17.Text = "Ср. кв. отклонение = ";
            // 
            // deviationLog
            // 
            this.deviationLog.AutoSize = true;
            this.deviationLog.Location = new System.Drawing.Point(181, 677);
            this.deviationLog.Name = "deviationLog";
            this.deviationLog.Size = new System.Drawing.Size(13, 17);
            this.deviationLog.TabIndex = 34;
            this.deviationLog.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(26, 677);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 17);
            this.label18.TabIndex = 33;
            this.label18.Text = "Ср. кв. отклонение = ";
            // 
            // deviationPolinom
            // 
            this.deviationPolinom.AutoSize = true;
            this.deviationPolinom.Location = new System.Drawing.Point(181, 724);
            this.deviationPolinom.Name = "deviationPolinom";
            this.deviationPolinom.Size = new System.Drawing.Size(13, 17);
            this.deviationPolinom.TabIndex = 36;
            this.deviationPolinom.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 724);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(149, 17);
            this.label19.TabIndex = 35;
            this.label19.Text = "Ср. кв. отклонение = ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 741);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 17);
            this.label16.TabIndex = 37;
            this.label16.Text = "Степень полинома = ";
            // 
            // polinomPower
            // 
            this.polinomPower.AutoSize = true;
            this.polinomPower.Location = new System.Drawing.Point(180, 741);
            this.polinomPower.Name = "polinomPower";
            this.polinomPower.Size = new System.Drawing.Size(13, 17);
            this.polinomPower.TabIndex = 38;
            this.polinomPower.Text = "-";
            // 
            // checkLinear
            // 
            this.checkLinear.AutoSize = true;
            this.checkLinear.Location = new System.Drawing.Point(207, 381);
            this.checkLinear.Name = "checkLinear";
            this.checkLinear.Size = new System.Drawing.Size(18, 17);
            this.checkLinear.TabIndex = 39;
            this.checkLinear.UseVisualStyleBackColor = true;
            // 
            // checkExp
            // 
            this.checkExp.AutoSize = true;
            this.checkExp.Location = new System.Drawing.Point(264, 464);
            this.checkExp.Name = "checkExp";
            this.checkExp.Size = new System.Drawing.Size(18, 17);
            this.checkExp.TabIndex = 40;
            this.checkExp.UseVisualStyleBackColor = true;
            // 
            // checkPower
            // 
            this.checkPower.AutoSize = true;
            this.checkPower.Location = new System.Drawing.Point(213, 547);
            this.checkPower.Name = "checkPower";
            this.checkPower.Size = new System.Drawing.Size(18, 17);
            this.checkPower.TabIndex = 41;
            this.checkPower.UseVisualStyleBackColor = true;
            // 
            // checkLog
            // 
            this.checkLog.AutoSize = true;
            this.checkLog.Location = new System.Drawing.Point(259, 627);
            this.checkLog.Name = "checkLog";
            this.checkLog.Size = new System.Drawing.Size(18, 17);
            this.checkLog.TabIndex = 42;
            this.checkLog.UseVisualStyleBackColor = true;
            // 
            // checkPolinom
            // 
            this.checkPolinom.AutoSize = true;
            this.checkPolinom.Location = new System.Drawing.Point(283, 708);
            this.checkPolinom.Name = "checkPolinom";
            this.checkPolinom.Size = new System.Drawing.Size(18, 17);
            this.checkPolinom.TabIndex = 43;
            this.checkPolinom.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(17, 834);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 53);
            this.button5.TabIndex = 44;
            this.button5.Text = "Результаты полученных функций";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1792, 984);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkPolinom);
            this.Controls.Add(this.checkLog);
            this.Controls.Add(this.checkPower);
            this.Controls.Add(this.checkExp);
            this.Controls.Add(this.checkLinear);
            this.Controls.Add(this.polinomPower);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.deviationPolinom);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.deviationLog);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.deviationPower);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.deviationExp);
            this.Controls.Add(this.deviationLinear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.logResB);
            this.Controls.Add(this.logResA);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.powerResultB);
            this.Controls.Add(this.powerResultA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.expResultB);
            this.Controls.Add(this.expResultA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.linearResultB);
            this.Controls.Add(this.linearResultA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аппроксимация";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label linearResultA;
        private System.Windows.Forms.Label linearResultB;
        private System.Windows.Forms.Label expResultB;
        private System.Windows.Forms.Label expResultA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label powerResultB;
        private System.Windows.Forms.Label powerResultA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label logResB;
        private System.Windows.Forms.Label logResA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label deviationLinear;
        private System.Windows.Forms.Label deviationExp;
        private System.Windows.Forms.Label deviationPower;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label deviationLog;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label deviationPolinom;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label polinomPower;
        private System.Windows.Forms.CheckBox checkLinear;
        private System.Windows.Forms.CheckBox checkExp;
        private System.Windows.Forms.CheckBox checkPower;
        private System.Windows.Forms.CheckBox checkLog;
        private System.Windows.Forms.CheckBox checkPolinom;
        private System.Windows.Forms.Button button5;
    }
}

