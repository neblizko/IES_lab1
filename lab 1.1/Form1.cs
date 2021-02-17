using System;
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
            double M = Program.calculateM(s);
            double D = Program.calculateD(M, s);
            Console.WriteLine("Chart was drawn");
            fillForm(s, M, D);
        }

        public void fillForm(double[] s, double M, double D)
        {
            Console.WriteLine(s.Length.ToString());
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i].ToString());

                chart1.Series["Signal"].Points.AddXY(i, s[i]);
            }
            m_value.Text = M.ToString();
            d_value.Text = D.ToString();

        }
    }
}
