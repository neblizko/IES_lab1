using System;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         ///**********************FERM*********************///
        static ulong[] FermatFactor(ulong n)
        {
            ulong a, b;

            if ((n % 2UL) == 0)
            {
                return new[] { 2UL, n / 2UL };
            }

            a = Convert.ToUInt64(Math.Ceiling(Math.Sqrt(n)));
            if (a * a == n)
            {
                return new[] { a, a };
            }

            while (true)
            {
                ulong tmp = a * a - n;
                b = Convert.ToUInt64(Math.Sqrt(tmp));

                if (b * b == tmp)
                {
                    break;
                }

                a++;
            }

            return new[] { a - b, a + b };
        }
        private void fermButton_Click(object sender, EventArgs e)
        {
            ulong num = ulong.Parse(fermInput.Text);
            ulong[] arr = FermatFactor(num);
            fermResult.Text = string.Concat(arr[0].ToString(), ", ", arr[1].ToString());
        }
        ///************************************************///

        ///*******************PERCEPTRON*******************///
        private void percButton_Click(object sender, EventArgs e)
        {
            double[,] data = new double[4, 2]
            { { 0, 6 },
              { 1, 5 },
              { 3, 3 },
              { 2, 4 }
            };
            float speed = float.Parse(percSigma.Text);
            int iterations = int.Parse(percIterations.Text);
            float p = 4;
            float y, delta;
            float w1 = 0;
            float w2 = 0;
            int i = 0;

            while (i < iterations)
            {
                Console.WriteLine(i % 4);
                double[] curPoint = { data[i % 4, 0], data[i % 4, 1] };
                y = Convert.ToSingle(curPoint[0]) * w1 + Convert.ToSingle(curPoint[1]) * w2;
                if ((y > p && (i % 4 == 0 || i % 4 == 1)) || (y < p && (i % 4 == 2 || i % 4 == 3)))
                {
                    bool res = true;
                    for(int j = 0; j<4; j++)
                    {
                        if (j < 2)
                        {
                            res = (Convert.ToSingle(data[j, 0]) * w1 + Convert.ToSingle(data[j, 1]) * w2) > p;
                        } else
                        {
                            res = (Convert.ToSingle(data[j, 0]) * w1 + Convert.ToSingle(data[j, 1]) * w2) < p;
                        }

                        if (!res)
                        {
                            break;
                        }
                    }
                    if (res)
                    {
                        Console.WriteLine(w1.ToString(), w2);
                        percResult.Text = string.Concat(w1.ToString(), ", ", w2.ToString());
                    }

                }

                delta = p - y;
                w1 = w1 + delta * speed * Convert.ToSingle(curPoint[0]);
                w2 = w2 + delta * speed * Convert.ToSingle(curPoint[1]);
                i += 1;
            }

        }
    }
}
