using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

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
            double[] copyS2 = s;
            double[] dft = Program.dft(copyS2);
            Complex[] fft = Program.fft(copyS2, 6, 64);
            double[,] time = Program.complexity();

            fillForm(s, dft, Program.cTor(fft), time);
        }

        public void fillForm(double[] s, double[] dft, double[] fft, double[,] time)
        {
            for (int i = 0; i < s.Length; i++)
            {

                chart1.Series["Signal"].Points.AddXY(i, s[i]);
                chart2.Series["dft"].Points.AddXY(i, dft[i]);
                chart4.Series["fft"].Points.AddXY(i, fft[i]);

            }

            for (int i = 1; i < 11; i++)
            {
                chart3.Series["dft time"].Points.AddXY(Math.Pow(2, i), time[0, i - 1]);
                chart3.Series["fft time"].Points.AddXY(Math.Pow(2, i), time[1, i - 1]);

            }
        }
    }
}
