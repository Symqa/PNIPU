using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Lab1
{
	struct maxElement
	{
		public double value;
		public int i;
		public int j;
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			double[,] matrix = new double[3, 4];
			string dataFilePath = "Исходные данные.txt";
			GetMatrixFromFile(dataFilePath, ref matrix);
			double[,] matrixForTest = (double[,])matrix.Clone();

			Console.WriteLine("\n================ Обработка методом Гауса ================");
			PrintMatrix(matrix);
			int j = matrix.GetLength(0)-1;
			int i = matrix.GetLength(1)-1;
			double Eps = 1e-12;
			while (!(matrix[0, 1] < Eps && matrix[0, 2] < Eps))
			{
				Step(matrix, j, i);
				PrintMatrix(matrix);
				i--;
				j--;
			}


			double[] unknowns = new double[matrix.GetLength(0)];
			CalculateUnknowns(matrix, ref unknowns);
			TestResults(matrixForTest, unknowns);

		}

		static void PrintMatrix(double[,] matrix)
		{
			for (int j = 0; j < matrix.GetLength(0); j++)
			{
				for (int i = 0; i < matrix.GetLength(1); i++) 
				{
					Console.Write($"{matrix[j, i]:F4} ");
					if (i == 2)
						Console.Write("| ");
					
				}
				Console.Write("\n");
			}
		}

		static void CalculateUnknowns(double[,] matrix, ref double[] unknowns)
		{
			Console.WriteLine("\n================ Расчёт неизвестных ================");
            int j = 0; // первая строка - всегда x1, вторая - x2 и т.д
            for (int k = 0; k < unknowns.Length; k++)
            {
                double sum = 0; // сумма известных x-сов умноженных на их коэффиценты
                for (int i = 0; i < k; i++)
                {
					// i - индекс x-cа и его коэффицента
                    sum += unknowns[i] * matrix[j, i];
                }
				// вычитаем посчитанные известные из правой части равенства, затем делим и получаем неизвестную
                unknowns[k] = (matrix[j, matrix.GetLength(1) - 1] - sum) / matrix[j, k];
				Console.WriteLine($"x{k + 1} = {unknowns[k]:F4}");
                j++; // переходим к следующей строке
            }
        }

		static void TestResults(double[,] matrix, double[] unknowns)
		{
			Console.WriteLine("\n================ Тестирование полученных неизвестных ================ ");
			for (int j = 0; j < matrix.GetLength(0); j++)
			{
				double result = 0;
				// перебор левой части равенства
				for (int i = 0; i < matrix.GetLength(1) - 1; i++)
				{
					result += matrix[j, i] * unknowns[i];

					Console.Write($"{matrix[j, i]:F4}*({unknowns[i]:F4})");
					if (i == matrix.GetLength(1) - 2)
						Console.Write(" = ");
					else
						Console.Write(" + ");
					
				}
				Console.Write($"{result:F4} | {matrix[j, matrix.GetLength(1)-1]}\n");
			}
		}

		static void Step(double[,] matrix, int max_j, int max_i)
		{
            // находим максимум
            maxElement max = GetMaxFromMatrix(matrix, max_j, max_i);
            Console.WriteLine($"Максимальный элемент в матрице: {max.value:F4}\n");
            double[] multipliers = new double[max_j+1];
            // вычисляем коэффиценты
            for (int j = 0; j < multipliers.Length; j++)
            {
                multipliers[j] = (-(matrix[j, max.i] / max.value));
            }
            // домножаем каждую строчку на соотвествующий коэффицент и складываем
            for (int j = 0; j <= max_j-1; j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[j, i] += matrix[max.j, i] * multipliers[j];
                }
            }
        }

		static maxElement GetMaxFromMatrix(double [,] matrix, int max_j, int max_i)
		{
            maxElement max = new maxElement
            {
                value = matrix[0, 0],
                i = 0,
                j = 0
            };
			// находим максимальный элемент
            for (int j = 0; j <= max_j; j++)
			{
				for (int i = 0; i <= max_i-1; i++)
				{
					if (matrix[j, i] > max.value)
					{
                        max.value = matrix[j, i];
                        max.i = i;
                        max.j = j;
                    }
				}
			}
			// переставляем строку с максимальным элементов в конец, если она не там
			if (max.j < max_j)
			{
				for (int i = 0; i < matrix.GetLength(1); i++)
				{
					double temp = matrix[max.j, i]; // сохраняем элемент строки, которую необходимо перенести
					matrix[max.j, i] = matrix[max_j, i]; // копируем элемент в последней строке в строку с максимумом
					matrix[max_j, i] = temp; // переносим максимум в конец
				}
			}
			
			return max;
		}

		static void GetMatrixFromFile(string dataFilePath, ref double[,] matrix) 
		{
			if (File.Exists(dataFilePath))
			{
				string data = File.ReadAllText(dataFilePath);
				int i, j = 0;
				foreach (string line in data.Split('\n'))
				{
					i = 0;
					foreach (string number in line.Split(' '))
					{
						double.TryParse(number, out matrix[j, i]);
						i++;
					}
					j++;
				}
			}
			else
			{
				Console.WriteLine($"\nФайла с путём {dataFilePath} не существует!");
			}
		}
	}
}
