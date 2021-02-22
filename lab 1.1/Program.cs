using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

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

        public static double calculateM(double[] arr)
        {
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum / arr.Length;
        }

        public static double calculateD(double M, double[] arr)
        {
            double sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += ((arr[i] - M) * (arr[i] - M));
            }

            return sum / (arr.Length - 1);
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

        public static List<double> generateSignalList(int CALLS_NUMBER, int HARMONICS_NUMBER, int BORDER_FREQUENCY)
        {
            List<double> signals = new List<double> {};
            var rand = new Random();

            for (int i = 1; i <= HARMONICS_NUMBER; i++)
            {
                double frequency = (i * BORDER_FREQUENCY) / HARMONICS_NUMBER;
                double amplitude = rand.NextDouble();
                Thread.Sleep(25); // to refresh random seed
                double phase = rand.NextDouble();
                for (int time = 0; time < CALLS_NUMBER; time++)
                {
                    double signal = amplitude * Math.Sin((frequency * time) + phase);
                    signals.Add(signal);
                }
            }

            return signals;
        }


        public static double[] corFunc(double[] x, double[] y)
        {
            double[] corValues = new double[CALLS_NUMBER/2];
            double avgX = x.Average();
            double avgY = y.Average();
            double stdevX = Math.Sqrt(calculateD(avgX, x));

            int half = CALLS_NUMBER / 2;
            double v, m, std;
            for(int i = 0; i<half; i++)
            {
                v = 0;
                for(int j = 0;j< x.Length-i; j++)
                {
                    v += x[j] * y[j + i];
                    m = y.Average();
                    std = Math.Sqrt(calculateD(avgY,y));
                    corValues[i] = (v / (x.Length - i) - avgX * m) / (stdevX * std);
                }
            }


            return corValues;
        }

        public static double[] autoCorFunc(double [] signals)
        {
            return corFunc(signals, signals);
        }

        public static double[] complexity()
        {
            double[] time = new double[CALLS_NUMBER];
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < CALLS_NUMBER; i++)
            {
                sw.Start();
                generateSignal(i, HARMONICS_NUMBER, BORDER_FREQUENCY);
                sw.Stop();
                time[i] = sw.ElapsedMilliseconds/100;
            }
            return time;
        }

        public static double[] complexityList()
        {
            double[] time = new double[CALLS_NUMBER];
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < CALLS_NUMBER; i++)
            {
                sw.Start();
                generateSignalList(i, HARMONICS_NUMBER, BORDER_FREQUENCY);
                sw.Stop();
                time[i] = sw.ElapsedMilliseconds / 100;
            }
            return time;
        }
    }
}
