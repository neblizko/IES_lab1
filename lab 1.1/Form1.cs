﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

            double[] s = Program.generateSignal(Program.CALLS_NUMBER, Program.HARMONICS_NUMBER, Program.BORDER_FREQUENCY);
            double[] copyS = Program.generateSignal(Program.CALLS_NUMBER, Program.HARMONICS_NUMBER, Program.BORDER_FREQUENCY);
            double M = Program.calculateM(s);
            double D = Program.calculateD(M, s);
            double[] cor = Program.corFunc(s, copyS);
            double[] autocor = Program.autoCorFunc(s);
            double[] time = Program.complexity();
            fillForm(s, copyS, cor, autocor, M, D, time);
        }

        public void fillForm(double[] s, double[] copyS, double[] cor, double[] autocor, double M, double D, double[] time)
        {

            Console.WriteLine("[{0}]", string.Join(", ", time));


            for (int i = 0; i < s.Length; i++)
            {

                chart1.Series["Signal"].Points.AddXY(i, s[i]);
                chart1.Series["Signal copy"].Points.AddXY(i, copyS[i]);
                chart2.Series["Complexity"].Points.AddXY(i, time[i]);

            }

            for (int i = 0; i<cor.Length; i++)
            {
                chart3.Series["cor"].Points.AddXY(i, cor[i]);
                chart4.Series["autocor"].Points.AddXY(i, autocor[i]);
            }
            m_value.Text = M.ToString();
            d_value.Text = D.ToString();

        }
    }
}
