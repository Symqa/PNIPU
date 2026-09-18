using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	internal class Program
	{
		static void Main(string[] args)
		{
		}

		double Function(double x) {
			return -Math.Log(Math.Abs(2 * Math.Sin(x / 2)));
		}
	}
}
