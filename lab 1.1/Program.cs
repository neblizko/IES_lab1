using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1._1
{
    public class Program
    {

        public const int HARMONICS_NUMBER = 12;
        public const int BORDER_FREQUENCY = 1800;
        public const int CALLS_NUMBER = 64;

        static void Main()
        {
            Console.WriteLine("Program started");
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
                double phase = rand.NextDouble();
                for(int time = 0; time < CALLS_NUMBER; time++)
                {
                    double signal = amplitude * Math.Sin((frequency * time) + phase);
                    signals[time] += signal;
                }
            }
            
            Console.WriteLine(signals);
            return signals;
        }


    }
}
