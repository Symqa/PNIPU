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
			int choice;
			do
			{
				choice = GetMenuChoice("Меню: \n" +
								   "1. Задача 1\n" +
								   "2. Задача 2\n" +
								   "3. Задача 3\n" +
								   "4. Выход",
								   4);
				switch (choice)
				{
					case 1:
						// ЗАДАЧА 1
						Console.WriteLine("Задача 1");
						int n = 0, m = 0, x = 0;
						MyParse(ref n, "n");
						MyParse(ref m, "m");
						MyParse(ref x, "x", "Введите (кроме диапазона [-1:1] ");

						Console.WriteLine($"n = {n}, m = {m}");
						Results(1, ++n * ++m);
						Console.WriteLine($"n = {n}, m = {m}");
						Results(2, m++ < n);
						Console.WriteLine($"n = {n}, m = {m}");
						Results(3, n++ > m);
						Console.WriteLine($"x = {x}");
						Results(4, x + (1 / (Math.Pow(x, 3) - x)) - 2);

						Console.WriteLine($"n = {n}, m = {m}, x = {x}");
						break;
					case 2:
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
						} while (!int.TryParse(Console.ReadLine(), out y));

						output = $"Точка ({x}, {y}) принадлежит области: ";
						result = (
							(x >= -7 && x <= 0)
							&& (y >= -7 && y <= 0)
							);
						Console.WriteLine(output + result);
						break;
					case 3:
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
						break;
					case 4:
						Console.WriteLine("Выход.");
						break;
				}
			} while (choice != 4);
		}


		public static int GetMenuChoice(string text, int maxParam) {
			int choice;	
			do {
				Console.WriteLine(text);
			} while (!int.TryParse(Console.ReadLine(), out choice) | (choice < 1 | choice > maxParam));
			return choice;
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
			float aMinusB_f = a - b;
			float sqrDiff_f = aMinusB_f * aMinusB_f;
			float aSqr_f = a * a;
			float twoAB_f = 2 * a * b;
			float numerator_f = sqrDiff_f - (aSqr_f - twoAB_f);
			float bSqr_f = b * b;
			float result_f = numerator_f / bSqr_f;
			Console.WriteLine("Результат для float: {0}", result_f);
			Console.WriteLine("\nПромежуточные значения (float):");
			Console.WriteLine("(a-b)^2 = {0}", sqrDiff_f);
			Console.WriteLine("a^2 - 2ab = {0}", aSqr_f - twoAB_f);
			Console.WriteLine("Числитель = {0}", numerator_f);
			Console.WriteLine("b^2 = {0}\n", bSqr_f);
		}

		public static void CalculateExpression(double a, double b) {
			double aMinusB_d = a - b;
            double sqrDiff_d = aMinusB_d * aMinusB_d;      // (a-b)^2
            double aSqr_d = a * a;                     // a^2
            double twoAB_d = 2 * a * b;                // 2ab
            double numerator_d = sqrDiff_d - (aSqr_d - twoAB_d);
            double bSqr_d = b * b;                     // b^2
            double result_d = numerator_d / bSqr_d;
			Console.WriteLine("Результат для double: {0}", result_d);
			Console.WriteLine("\nПромежуточные значения (double):");
			Console.WriteLine("(a-b)^2 = {0}", sqrDiff_d);
			Console.WriteLine("a^2 - 2ab = {0}", aSqr_d - twoAB_d);
			Console.WriteLine("Числитель = {0}", numerator_d);
			Console.WriteLine("b^2 = {0}", bSqr_d);

		}
	}
}