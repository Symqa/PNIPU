using System;


namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] dynamicArray = null;
            int[][] jaggedArray = null;
            string str = "В лесу родилась елочка.В лесу она росла.Зимой и летом стройная, зеленая была.";
            int choice;
            do
            {
                choice = GetMenuChoice(
                    "\nГлавное меню:\n" +
                    "1. Работа с двумерными массивами\n" +
                    "2. Работа с рваными массивами\n" +
                    "3. Работа со строками\n" +
                    "4. Выход",
                    4
                );

                switch (choice)
                {
                    case 1:
                        StartTwoDimensionalArrays(ref dynamicArray);
                        break;
                    case 2:
                        StartJaggedArray(ref jaggedArray);
                        break;
                    case 3:
                        StartString(ref str);
                        break;
                    case 4:
                        Console.WriteLine("Выход");
                        break;
                }
            } while (choice != 3);
        }

        static void StartTwoDimensionalArrays(ref int [ , ] dynamicArray)
        {
            int choice;
            do
            {
                choice = GetMenuChoice(
                    "\n1. Создать массив\n" +
                    "2. Вывести массив\n" +
                    "3. Добавить столбец с заданным номером\n" +
                    "4. Назад",
                    4
                );

                switch (choice)
                {
                    case 1:
                        int countColumns, countLines;
                        MyIntParse(out countLines, "Введите количество подмассивов: ");
                        MyIntParse(out countColumns, "Введите размер подмассива: ");
     
                        dynamicArray = new int[countLines, countColumns]; 
                        
                        int arrayInitChoice = GetMenuChoice(
                                            "\nЗаполнение массива:\n" +
                                            "1. Вручную\n" +
                                            "2. С помощью датчика случайных чисел\n",
                                            2);
                        Random rnd = new Random();
                        for (int i = 0; i < dynamicArray.GetLength(0); i++)
                        {
                            for (int j = 0; j < dynamicArray.GetLength(1); j++)
                            {
                                int number;
                                if (arrayInitChoice == 1)
                                {
                                    MyIntParse(out number, $"Введите {j + 1} элемент {i + 1} массива: ");
                                } 
                                else
                                {
                                    number = rnd.Next(1, 11);
                                }
                                dynamicArray[i, j] = number;
                            }
                        }
                        break;
                    case 2:
                        PrintArray(ref dynamicArray);
                        break;
                    case 3:
                        int newColumnNumber;
                        MyIntParse(out newColumnNumber, $"Введите номер столбца для добавления (от 1 до {dynamicArray.GetLength(1) + 1}): ");

                        if (newColumnNumber <= 0 || newColumnNumber > dynamicArray.GetLength(1)+1)
                        {
                            Console.WriteLine("Невозможно вставить столбец под таким номером.");
                            break;
                        }

                        int element_1, element_2;
                        MyIntParse(out element_1, "Введите первый элемент столбца: ");
                        MyIntParse(out element_2, "Введите второй элемент столбца: ");

                        int oldI, oldJ;
                        int[ , ] dynamicArrayCopy = new int[dynamicArray.GetLength(0), dynamicArray.GetLength(1)+1];

                        oldI = 0;
                        for (int newI = 0; newI < dynamicArrayCopy.GetLength(0);newI++)
                        {
                            oldJ = 0;
                            for (int newJ = 0; newJ < dynamicArrayCopy.GetLength(1);newJ++)
                            {
                                if (newJ == newColumnNumber - 1)
                                {
                                    if (newI == 0)
                                    {
                                        dynamicArrayCopy[newI, newJ] = element_1;
                                    } 
                                    else
                                    {
                                        dynamicArrayCopy[newI, newJ] = element_2;
                                    }
                                    newJ++;

                                }
                                if (oldI < dynamicArray.GetLength(0) && oldJ < dynamicArray.GetLength(1))
                                {
                                    dynamicArrayCopy[newI, newJ] = dynamicArray[oldI, oldJ];
                                    oldJ++;
                                }
                            }
                            oldI++;
                        }
                        dynamicArray = dynamicArrayCopy;
                        break;
                    case 4:
                        Console.WriteLine("Возврат назад...");
                        break;
                }
            } while (choice != 4);
        }


        static void StartJaggedArray(ref int[][] jaggedArray)
        {
            int choice;
            do
            {
                choice = GetMenuChoice(
                    "\n1. Создать массив\n" +
                    "2. Вывести массив\n" +
                    "3. Удалить самую короткую строку\n" +
                    "4. Назад",
                    4
                );

                switch (choice)
                {
                    case 1:
                        int countLines;
                        MyIntParse(out countLines, "Введите количество подмассивов: ");
                        jaggedArray = new int[countLines][];
                        int arrayInitChoice = GetMenuChoice(
                                           "\nЗаполнение массива:\n" +
                                           "1. Вручную\n" +
                                           "2. С помощью датчика случайных чисел\n",
                                           2);
                        Random rnd = new Random();
                        for (int i = 0; i < countLines; i++)
                        {
                            int countColumns;
                            MyIntParse(out countColumns, $"Введите количество элементов в {i + 1} массиве: ");
                            jaggedArray[i] = new int[countColumns];
                            int number;
                            for (int j = 0; j < countColumns; j++)
                            {
                                if (arrayInitChoice == 1)
                                {
                                    MyIntParse(out number, $"Введите {j + 1} элемент для {i + 1} массива: ");
                                    jaggedArray[i][j] = number;
                                }
                                else
                                {
                                    jaggedArray[i][j] = rnd.Next(1, 11);
                                }
                            }     
                        }
                        break;
                    case 2:
                        PrintArray(ref jaggedArray);
                        break;
                    case 3:
                        if (jaggedArray.Length == 0)
                        {
                            Console.WriteLine("Массив пуст.");
                            break;
                        }
                        else if (jaggedArray.Length == 1)
                        {
                            jaggedArray = null;
                            break;
                        }

                        int minLineIndex = 0;
                        int minLineSize = jaggedArray[0].Length;

                        int[][] jaggedArrayCopy = new int[jaggedArray.Length - 1][];
                        for (int i = 1; i < jaggedArray.Length; i++)
                        {
                            if (minLineSize > jaggedArray[i].Length)
                            {
                                minLineSize = jaggedArray[i].Length;
                                minLineIndex = i;
                            }
                        }

                        int oldI = 0;
                        for (int newI = 0; newI < jaggedArrayCopy.Length; newI++)
                        {
                            if (minLineIndex != newI)
                            {
                                int size = jaggedArray[oldI].Length;
                                jaggedArrayCopy[newI] = new int[size];

                                for (int j = 0; j < size; j++)
                                {
                                    jaggedArrayCopy[newI][j] = jaggedArray[oldI][j];
                                }
                            }
                            else
                            {
                                newI--;
                                minLineIndex = -1; // обнуляем индекс, чтобы больше не срабатывало ненужное условие пропуска копирования прошлой строки
                            }
                            oldI++;
                        }
                        jaggedArray = jaggedArrayCopy;
                        // логика удаления строки
                        break;
                    case 4:
                        Console.WriteLine("Возврат назад...");
                        break;
                }
            } while (choice != 4);
        }


        static void StartString(ref string str)
        {
            
        }

        // Вывод меню (против дублирования кода)
        static int GetMenuChoice(string menuText, int maxOption)
        {
            int choice;
            while (true)
            {
                Console.WriteLine(menuText);
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= maxOption)
                    {
                        return choice;
                    }
                }
                Console.WriteLine($"Ошибка: введите число от 1 до {maxOption}.");
            }
        }

        // Удобное получение целочисленного ввода
        static void MyIntParse(out int var, string text = "Введите число: ")
        {
            do
            {
                Console.WriteLine(text);
            } while (!int.TryParse(Console.ReadLine(), out var));

        }

        // ======= Вывод массивов ==========
        static void PrintArray(ref int[ , ] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void PrintArray(ref int[][] array)
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Массив пуст.");
                return;
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
