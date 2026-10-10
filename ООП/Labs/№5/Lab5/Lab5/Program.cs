using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                choice = GetMenuChoice(
                    "\nГлавное меню:\n" +
                    "1. Работа с двумерными массивами\n" +
                    "2. Работа с рваными массивами\n" +
                    "3. Выход",
                    3
                );

                switch (choice)
                {
                    case 1:
                        StartTwoDimensionalArrays();
                        break;
                    case 2:
                        StartJaggedArray();
                        break;
                    case 3:
                        Console.WriteLine("Выход");
                        break;
                }
            } while (choice != 3);
        }

        static void StartTwoDimensionalArrays()
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
                        // логика создания
                        break;
                    case 2:
                        // логика вывода
                        break;
                    case 3:
                        // логика добавления столбца
                        break;
                    case 4:
                        Console.WriteLine("Возврат назад...");
                        break;
                }
            } while (choice != 4);
        }

        static void StartJaggedArray()
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
                        // логика создания
                        break;
                    case 2:
                        // логика вывода
                        break;
                    case 3:
                        // логика удаления строки
                        break;
                    case 4:
                        Console.WriteLine("Возврат назад...");
                        break;
                }
            } while (choice != 4);
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
    }
}
