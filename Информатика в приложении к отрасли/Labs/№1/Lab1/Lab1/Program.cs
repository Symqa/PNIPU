using System;
using System.IO;

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
            Console.WriteLine("=================================================================");
            Console.WriteLine("   ЗАДАНИЕ 1: Метод Гаусса с выбором главного элемента");
            Console.WriteLine("=================================================================\n");

            RunGaussTask();

            Console.WriteLine("\n\n=================================================================");
            Console.WriteLine("   ЗАДАНИЕ 2: Метод простой итерации (Вариант 27)");
            Console.WriteLine("=================================================================\n");

            RunIterationTask();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadLine();
        }

        // =================================================================
        //                       ЗАДАНИЕ 1 (МЕТОД ГАУССА)
        // =================================================================
        static void RunGaussTask()
        {
            double[,] matrix = new double[3, 4];
            string dataFilePath = "Исходные данные.txt";

            // Если файла нет, используем тестовую матрицу для демонстрации
            if (!File.Exists(dataFilePath))
            {
                Console.WriteLine($"Файл {dataFilePath} не найден. Используется встроенная матрица.");
                matrix = new double[,] {
                    { 2.4,  2.5, -2.9,  4.5 },
                    { 0.8,  3.5, -1.4,  3.2 },
                    { 1.5, -2.3,  8.6, -5.5 }
                };
            }
            else
            {
                GetMatrixFromFile(dataFilePath, ref matrix);
            }

            double[,] matrixForTest = (double[,])matrix.Clone();

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            int j = matrix.GetLength(0) - 1;
            int i = matrix.GetLength(1) - 1;
            double Eps = 1e-12;

            // Защита от бесконечного цикла и выхода за границы массива
            while (j > 0)
            {
                bool success = Step(matrix, j, i);
                if (!success)
                {
                    Console.WriteLine("\nСистема не имеет единственного решения (деление на ноль).");
                    return;
                }
                PrintMatrix(matrix);
                i--;
                j--;
            }

            double[] unknowns = new double[matrix.GetLength(0)];
            CalculateUnknowns(matrix, ref unknowns);
            TestResults(matrixForTest, unknowns);
        }

        static bool Step(double[,] matrix, int max_j, int max_i)
        {
            maxElement max = GetMaxFromMatrix(matrix, max_j, max_i);

            // Проверка на деление на ноль
            if (Math.Abs(max.value) < 1e-12)
            {
                return false;
            }

            Console.WriteLine($"\nМаксимальный элемент по модулю: {max.value:F4}");
            double[] multipliers = new double[max_j + 1];

            for (int j = 0; j < multipliers.Length; j++)
            {
                multipliers[j] = (-(matrix[j, max.i] / max.value));
            }

            for (int j = 0; j <= max_j - 1; j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    matrix[j, i] += matrix[max.j, i] * multipliers[j];
                }
            }
            return true;
        }

        static maxElement GetMaxFromMatrix(double[,] matrix, int max_j, int max_i)
        {
            maxElement max = new maxElement
            {
                value = matrix[0, 0],
                i = 0,
                j = 0
            };

            for (int j = 0; j <= max_j; j++)
            {
                for (int i = 0; i <= max_i - 1; i++)
                {
                    // Ищем наибольший ПО МОДУЛЮ элемент 
                    if (Math.Abs(matrix[j, i]) > Math.Abs(max.value))
                    {
                        max.value = matrix[j, i];
                        max.i = i;
                        max.j = j;
                    }
                }
            }

            if (max.j < max_j)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    double temp = matrix[max.j, i];
                    matrix[max.j, i] = matrix[max_j, i];
                    matrix[max_j, i] = temp;
                }
            }

            return max;
        }

        static void CalculateUnknowns(double[,] matrix, ref double[] unknowns)
        {
            Console.WriteLine("\n================ Расчёт неизвестных ================");
            int j = 0;
            for (int k = 0; k < unknowns.Length; k++)
            {
                double sum = 0;
                for (int i = 0; i < k; i++)
                {
                    sum += unknowns[i] * matrix[j, i];
                }
                unknowns[k] = (matrix[j, matrix.GetLength(1) - 1] - sum) / matrix[j, k];
                Console.WriteLine($"x{k + 1} = {unknowns[k]:F4}");
                j++;
            }
        }

        static void TestResults(double[,] matrix, double[] unknowns)
        {
            Console.WriteLine("\n================ Тестирование полученных неизвестных ================");
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                double result = 0;
                for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                {
                    result += matrix[j, i] * unknowns[i];
                    Console.Write($"{matrix[j, i]:F4}*({unknowns[i]:F4})");
                    if (i == matrix.GetLength(1) - 2)
                        Console.Write(" = ");
                    else
                        Console.Write(" + ");
                }
                Console.Write($"{result:F4} | {matrix[j, matrix.GetLength(1) - 1]}\n");
            }
        }

        static void PrintMatrix(double[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    Console.Write($"{matrix[j, i]:F4} ");
                    if (i == matrix.GetLength(1) - 2)
                        Console.Write("| ");
                }
                Console.Write("\n");
            }
        }

        static void GetMatrixFromFile(string dataFilePath, ref double[,] matrix)
        {
            string data = File.ReadAllText(dataFilePath);
            int j = 0;
            foreach (string line in data.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                int i = 0;
                foreach (string number in line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    double.TryParse(number, out matrix[j, i]);
                    i++;
                }
                j++;
            }
        }


        // =================================================================
        //                     ЗАДАНИЕ 2 (МЕТОД ИТЕРАЦИЙ)
        // =================================================================
        static void RunIterationTask()
        {
            // Матрица уже приведена к диагональному преобладанию
            double[,] A = {
                { 8.7,  5.2, -0.1 },
                { 0.8,  3.5, -1.4 },
                { 1.5, -2.3,  8.6 }
            };
            double[] b = { 8.0, 3.2, -5.5 };

            int n = b.Length;
            double[,] C = new double[n, n];
            double[] d = new double[n];

            for (int i = 0; i < n; i++)
            {
                d[i] = b[i] / A[i, i];
                for (int j = 0; j < n; j++)
                {
                    if (i == j) C[i, j] = 0;
                    else C[i, j] = -A[i, j] / A[i, i];
                }
            }

            double cubicNorm = GetCubicNorm(C);
            double octNorm = GetOctahedralNorm(C);

            Console.WriteLine("--- Проверка условий сходимости ---");
            Console.WriteLine($"Кубическая норма ||C||_inf = {cubicNorm:F4}");
            Console.WriteLine($"Октаэдрическая норма ||C||_1 = {octNorm:F4}");

            if (cubicNorm >= 1 && octNorm >= 1)
            {
                Console.WriteLine("Внимание: Условие сходимости (||C|| < 1) не выполнено!");
                return;
            }
            Console.WriteLine("Условие сходимости выполнено.\n");

            double[] xPrev = new double[n];
            double[] xCurr = new double[n];
            Array.Copy(d, xPrev, n);

            double eps = 1e-5;
            int iteration = 0;
            bool isConverged = false;

            Console.WriteLine("--- Итерационный процесс ---");
            Console.WriteLine($"Шаг {iteration,-3} | x1 = {xPrev[0],-9:F5} | x2 = {xPrev[1],-9:F5} | x3 = {xPrev[2],-9:F5}");

            while (!isConverged)
            {
                iteration++;
                for (int i = 0; i < n; i++)
                {
                    xCurr[i] = d[i];
                    for (int j = 0; j < n; j++)
                    {
                        xCurr[i] += C[i, j] * xPrev[j];
                    }
                }

                Console.WriteLine($"Шаг {iteration,-3} | x1 = {xCurr[0],-9:F5} | x2 = {xCurr[1],-9:F5} | x3 = {xCurr[2],-9:F5}");

                double normDiff = 0;
                double normCurr = 0;
                for (int i = 0; i < n; i++)
                {
                    if (Math.Abs(xCurr[i] - xPrev[i]) > normDiff)
                        normDiff = Math.Abs(xCurr[i] - xPrev[i]);

                    if (Math.Abs(xCurr[i]) > normCurr)
                        normCurr = Math.Abs(xCurr[i]);
                }

                if (normDiff / normCurr <= eps)
                {
                    isConverged = true;
                }
                else
                {
                    Array.Copy(xCurr, xPrev, n);
                }
            }

            Console.WriteLine($"\nРешение найдено за {iteration} итераций (с точностью {eps}).");
            Console.WriteLine($"Ответ: x1 = {xCurr[0]:F5}, x2 = {xCurr[1]:F5}, x3 = {xCurr[2]:F5}");
        }

        static double GetCubicNorm(double[,] C)
        {
            double max = 0;
            int n = C.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++) sum += Math.Abs(C[i, j]);
                if (sum > max) max = sum;
            }
            return max;
        }

        static double GetOctahedralNorm(double[,] C)
        {
            double max = 0;
            int n = C.GetLength(0);
            for (int j = 0; j < n; j++)
            {
                double sum = 0;
                for (int i = 0; i < n; i++) sum += Math.Abs(C[i, j]);
                if (sum > max) max = sum;
            }
            return max;
        }
    }
}