using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Lab1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double[,] matrix = new double[3, 4];
			string dataFilePath = "E:\\PNIPU\\Информатика в приложении к отрасли\\Labs\\№1\\Исходные данные.txt";
			GetMatrixFromFile(dataFilePath, ref matrix);
			PrintMatrix(matrix);
			double max = GetMaxFromMatrix(matrix);
			Console.WriteLine($"Максимальный элемент в матрице: {max}");

			double[] multipliers = new double[matrix.GetLength(0)-1];
			for 
		}

		static void PrintMatrix(double[,] matrix)
		{
			for (int j = 0; j < matrix.GetLength(0); j++)
			{
				for (int i = 0; i < matrix.GetLength(1); i++) 
				{
					Console.Write($"{matrix[j, i]} ");
					if (i == 2)
						Console.Write("| ");
					
				}
				Console.Write('\n');
			}
		}

		static double GetMaxFromMatrix(double [,] matrix)
		{
			double max = matrix[0, 0];
			for (int j = 0; j < matrix.GetLength(0); j++)
			{
				for (int i = 0; i < matrix.GetLength(1)-1; i++)
				{
					if (matrix[j, i] > max)
						max = matrix[j, i];
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
				Console.WriteLine($"Файла с путём {dataFilePath} не существует!");
			}
		}
	}
}
