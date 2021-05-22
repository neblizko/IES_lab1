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

        ///*******************GENETIC*******************///
        private int population = 50;
        private int max = 5;
        private long time = 50;
        private int[][] gens = new int[50][];
        
        int[] deltas = new int[50];
        double[] survival = new double[50];
        private int calculateDeltas (int a, int b, int c, int d, int y)
        {
            for (int i = 1; i < population+1; ++i)
            {
                //Console.WriteLine();
                //Console.WriteLine("[{0}]", string.Join(", ", gens[0])); 
                int result = a * gens[i-1][0] + b * gens[i-1][1] + c * gens[i-1][2] + d * gens[i-1][3];
                deltas[i-1] = Math.Abs(result - y);
                if (deltas[i-1] == 0) return i;
            }
            return -1;
        }

        private int getParent()
        {
            int[] chances = new int[50];

            for (int i = 0; i < population; i++)
            {
                chances[i] = (new Random().Next(1, max)) * deltas[i];
            }

           var gen = -Double.PositiveInfinity;
           int parent = 0;

            for (int i = 0; i < population; i++)
            {
                if (gen < chances[i])
                {
                    gen = chances[i];
                    parent = i;
                }
            }
            
            return parent;
        }
        //private int GetTime()
        //{

        //    DateTime OLDtime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //    TimeSpan diff = date.ToUniversalTime() - OLDtime;
        //    return Math.Floor(diff.TotalSeconds);
        //}
        private void geneticCount_Click(object sender, EventArgs e)
        {
            string res;
            int a = int.Parse(geneticA.Text);
            int b = int.Parse(geneticB.Text);
            int c = int.Parse(geneticC.Text);
            int d = int.Parse(geneticD.Text);
            int y = int.Parse(geneticY.Text);
            long start = DateTime.Now.Millisecond;

            for (int i = 0; i < population; i++)
            {
                gens[i] = new int[4];
                gens[i][0] = (new Random().Next(1, max));
                gens[i][1] = (new Random().Next(1, max));
                gens[i][2] = (new Random().Next(1, max));
                gens[i][3] = (new Random().Next(1, max));
            }

            int index = -1;
            for (int i = 0; i < population; ++i)
            {

                int result = a * gens[i][0] + b * gens[i][1] + c * gens[i][2] + d * gens[i][3];
                deltas[i] = Math.Abs(result - y);
                if (deltas[i] == 0) index = i;
            }

            if (index != -1)
            {
                geneticRes.Text = "x1 = " + gens[index][0].ToString() + " x2 = " + gens[index][1] + " x3 = " + gens[index][2] + " x4 = " + gens[index][3] + " delta = " + deltas[index];
            }

            long end = DateTime.Now.Millisecond;

            while (end - start < time)
            {
                if(end-start < 10)
                {
                    max += (new Random().Next(-5, 5))/10;
                    continue;
                }
                Console.WriteLine(end-start + " " + time);
                double allSurvival = 0;

                for (int i = 0; i < population; i++)
                {
                    allSurvival += 1 / deltas[i];
                }

                for (int i = 0; i < population; i++)
                {
                    survival[i] = (1 / deltas[i]) / allSurvival;
                }

                int father = getParent();
                int mother = getParent();

                int[][] children = new int[50][];

                for(int i = 0; i < population; i++)
                {
                    children[i] = new int[4];
                    children[i][0] = gens[father][0];
                    children[i][1] = gens[father][1];
                    children[i][2] = gens[father][2];
                    children[i][3] = gens[father][3];
                }
                gens = children;
                index = -1;
                for (int i = 0; i < population; ++i)
            {

                int result = a * gens[i][0] + b * gens[i][1] + c * gens[i][2] + d * gens[i][3];
                deltas[i] = Math.Abs(result - y);
                if (deltas[i] == 0) index = i;
            }

                if (index != -1)
                {
                    geneticRes.Text = "x1 = " + children[index][0] + " x2 = " + children[index][1] + " x3 = " + children[index][2] + " x4 = " + children[index][3] + " delta = " + deltas[index];
                }

                end = DateTime.Now.Millisecond;
            }

            var smallDelta = Double.PositiveInfinity;
            int deltaIndex = 0;
            for(int i = 0; i < population; i++)
            {
                if (deltas[i] < smallDelta)
                {
                    smallDelta = deltas[i];
                    deltaIndex = i;
                }
            }
            geneticRes.Text = "x1 = " + gens[deltaIndex][0].ToString() + " x2 = " + gens[deltaIndex][1] + " x3 = " + gens[deltaIndex][2] + " x4 = " + gens[deltaIndex][3] + " delta = " + deltas[deltaIndex];
        }
    }
}
