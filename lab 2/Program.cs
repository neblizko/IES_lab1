using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Numerics;

namespace lab1._1
{
    public class Program
    {
        
        public const int HARMONICS_NUMBER = 12; 
        public const int BORDER_FREQUENCY = 1800;
        public const int CALLS_NUMBER = 64;
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static double[] generateSignal(int CALLS_NUMBER, int HARMONICS_NUMBER, int BORDER_FREQUENCY)
        {
            double[] signals = new double[CALLS_NUMBER];
            var rand = new Random();

            for (int i = 1; i <= HARMONICS_NUMBER; i++) {
                double frequency = (i*BORDER_FREQUENCY) / HARMONICS_NUMBER;
                double amplitude = rand.NextDouble();
                Thread.Sleep(25); // to refresh random seed
                double phase = rand.NextDouble();
                for(int time = 0; time < CALLS_NUMBER; time++)
                {
                    double signal = amplitude * Math.Sin((frequency * time) + phase);
                    signals[time] += signal;
                }
            }
            
            return signals;
        }

        // LAB 2

        public static double[] dft(double[] data)
        {
            int n = data.Length;
            int m = n;
            double[] real = new double[n];
            double[] imag = new double[n];
            double[] result = new double[m];
            double pi_div = 2.0 * Math.PI / n;
            for (int w = 0; w < m; w++)
            {
                double a = w * pi_div;
                for (int t = 0; t < n; t++)
                {
                    real[w] += data[t] * Math.Cos(a * t);
                    imag[w] += data[t] * Math.Sin(a * t);
                }
                result[w] = Math.Sqrt(real[w] * real[w] + imag[w] * imag[w]);
            }
            return result;
        }

    

        public static double[] cTor(Complex[] d)
        {
            double[] res = new double[d.Length];

            for (int i = 0; i < d.Length; i++)
            {
                double real = d[i].Real;
                double imaginary = d[i].Imaginary;
                res[i] = Math.Sqrt(Math.Pow(real, 2)+Math.Pow(imaginary, 2));
            }
            return res;
        }

        const double PI = 3.1415926536;

        private static int bitReverse(int x, int log2n)
        {
            int n = 0;
            for (int i = 0; i < log2n; i++)
            {
                n <<= 1;
                n |= (x & 1);
                x >>= 1;
            }
            return n;
        }

        public static Complex[] fft(double[] a, int log2n, int N)
        {
            Complex[] A = new Complex[N];

            int n = N;

            for (int i = 0; i < n; ++i)
            {
                int rev = bitReverse(i, log2n);
                A[i] = a[rev];
            }


            Complex J = new Complex(0, 1);
            for (int s = 1; s <= log2n; ++s)
            {
                int m = 1 << s; 
                int m2 = m >> 1; 
                Complex w =  new Complex(1, 0);

            Complex wm = Complex.Exp(J * (PI / m2));
            for (int j = 0; j < m2; ++j)
            {
                for (int k = j; k < n; k += m)
                {

                    Complex t = w * A[k + m2];
                    Complex u = A[k];

                    A[k] = u + t;

                    A[k + m2] = u - t;
                }
                w *= wm;
            }
        }

            return A;
    }

        public static double[,] complexity()
        {
            double[,] res = new double[10, 10];

            for (int i = 1; i < 11; i++)
            {
                double[] signal = generateSignal((int)Math.Pow(2, i), HARMONICS_NUMBER, BORDER_FREQUENCY);
                res[0, i -1] = TimeMethodDft(signal);
                res[1, i-1] = TimeMethodFft(signal, i, (int)Math.Pow(2, i));
                Console.WriteLine(res[0, i-1]);

            }

            return res;
        }

        private static long TimeMethodDft(double[] param)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            dft(param);
            stopwatch.Stop();
            return stopwatch.ElapsedTicks/1000;
        }

        private static long TimeMethodFft(double[] param, int log2n, int N)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            fft(param, log2n, N);
            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }
    }
}
