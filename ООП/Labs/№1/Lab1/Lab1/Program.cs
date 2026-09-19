using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// ЗАДАЧА 1
			Console.WriteLine("Задача 1");
			int n = 0, m = 0, x = 0;
			MyParse(ref n, "n");
			MyParse(ref m, "m");
			MyParse(ref x, "x", "Введите (кроме диапазона [-1:1] ");

			Console.WriteLine($"n = {n}, m = {m}");
			Results(1, ++n*++m);
			Console.WriteLine($"n = {n}, m = {m}");
			Results(2, m++<n);
			Console.WriteLine($"n = {n}, m = {m}");
			Results(3, n++>m);
			Console.WriteLine($"x = {x}");
			Results(4, x + (1 / (Math.Pow(x, 3) - x)) - 2);

			Console.WriteLine($"n = {n}, m = {m}, x = {x}");
			// -----------------------------------------------------------
			// ЗАДАЧА 2
			Console.WriteLine("\nЗадача 2");
			x = 0;
			int y = 0;
			string output;
			bool result;
			do 
			{
				Console.WriteLine("Введите x: ");
			} while (!int.TryParse(Console.ReadLine(), out x));

			do 
			{
				Console.WriteLine("Введите y: ");
			} while (!int.TryParse(Console.ReadLine(),out y));

			output = $"Точка ({x}, {y}) принадлежит области: ";
			result = (
				(x >= -7 && x <= 0)
				&& (y >= -7 && y <= 0)
				);
			Console.WriteLine(output + result);
			// --------------------------------------------------------
			// ЗАДАЧА 3
			Console.WriteLine("\nЗадача 3");
			float floatA = 1000.0f;
			float floatB = 0.0001f;
			double doubleA = 1000.0;
			double doubleB = 0.0001;

			Console.WriteLine($"Результат вычислений float: ");
			CalculateExpression(floatA, floatB);
			Console.WriteLine($"Результат вычислений double: ");
			CalculateExpression(doubleA, doubleB);
		}


		// ЗАДАЧА 1
		public static void MyParse(ref int var, string varName, string text = "Введите ")
		{
			if (varName == "x") 
			{
				do
				{
					Console.WriteLine(text + varName + ": ");
				} while ( !(int.TryParse(Console.ReadLine(), out var)
							&& (var < -1 || var > 1) 
							));
			} else
			{
				do
				{
					Console.WriteLine(text + varName + ": ");
				} while (!(int.TryParse(Console.ReadLine(), out var)));
			}
		}

		public static void Results(int resultNumber, int expression)
		{
			Console.WriteLine($"Результат {resultNumber}: {expression}");
		}

		public static void Results(int resultNumber, bool expression)
		{
			Console.WriteLine($"Результат {resultNumber}: {expression}");
		}
		
		public static void Results(int resultNumber, double expression) {
			Console.WriteLine($"Результат {resultNumber}: {expression}");
		}
		// --------------------------------------------------------------------
		// ЗАДАЧА 3
		public static void CalculateExpression(float a, float b) {
			Console.WriteLine( (Math.Pow(a + b, 2) - (Math.Pow(a, 2) - 2 * a * b)) / Math.Pow(b, 2) );
		}

		public static void CalculateExpression(double a, double b) {
			Console.WriteLine((Math.Pow(a + b, 2) - (Math.Pow(a, 2) - 2 * a * b)) / Math.Pow(b, 2));
		}
	}
}