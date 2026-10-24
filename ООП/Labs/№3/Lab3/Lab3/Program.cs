using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double a = Math.PI/5, b = Math.PI*9/5;
			const int N = 140;
			const double Epsilon = 0.0001;

			double y, sumN, sumEpsilon;
			for (double x = a; x <= b; x+=((b-a)/10))
			{	
                sumN = GetSumN(x, N);
				sumEpsilon = GetSumEpsilon(x, Epsilon);
                y = Function(x);

				Console.WriteLine($"X={x,-10:f2} " + $"SN={sumN, -10:f4} " + $"SE={sumEpsilon,-10:f4} " + $"Y = {y,-10:f4}");
			}
			
		}

		static double Function(double x) 
		{
			return -Math.Log(Math.Abs(2 * Math.Sin(x / 2)));
		}

		static double Fi(double x, int n)
		{
			return Math.Cos(n * x) / n;
		}

		static double GetSumN(double x, int n)
		{
			double sumN = 0.0;
            for (int i = 1; i <= n; i++)
            {
                sumN += Fi(x, i);
            }
			return sumN;
        }
		
		static double GetSumEpsilon(double x, double Epsilon)
		{
			double sumEpsilon = 0.0, prevSumEpsilonElement;
			int n = 1;
			do
			{
				prevSumEpsilonElement = Fi(x, n);
				sumEpsilon += prevSumEpsilonElement;
				n++;
			} while (Math.Abs(prevSumEpsilonElement) >= Epsilon);
			return sumEpsilon;
		}
	}
}
