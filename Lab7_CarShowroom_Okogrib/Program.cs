using System;
using System.Text;

namespace CarShowroom_Okogrib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool running = true;

            while (running)
            {
                Console.WriteLine("АВТОСАЛОН");
                Console.WriteLine("1. Про програму");
                Console.WriteLine("2. Таблиця вартості авто залежно від пробігу");
                Console.WriteLine("3. Зведена таблиця продажу машин за місяцями");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть пункт меню: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAbout();
                        Pause();
                        break;
                    case "2":
                        ShowCostTable();
                        Pause();
                        break;
                    case "3":
                        ShowWorkloadTable();
                        Pause();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Роботу програми завершено. До побачення!");
                        break;
                    default:
                        Console.WriteLine("Помилка: такого пункту меню не існує. Спробуйте ще раз.");
                        Pause();
                        break;
                }
            }
        }

        static void ShowAbout()
        {
            Console.WriteLine("ДОВІДКА ПРО ПРОГРАМУ");
            Console.WriteLine("Тема проекту: 16. Автосалон");
            Console.WriteLine("Головна сутність: Автомобіль");
            Console.WriteLine("Перелік полів:");
            Console.WriteLine("VIN - string");
            Console.WriteLine("Марка - string");
            Console.WriteLine("Код моделі - int");
            Console.WriteLine("Рік випуску - int");
            Console.WriteLine("Пробіг - int");
            Console.WriteLine("Колір - string");
            Console.WriteLine("Ціна - double");
            Console.WriteLine("Чи проданий - bool");
            Console.WriteLine("Підсумкова величина: середня ціна за марками та кількість проданих авто за місяць.");
        }

        static void ShowCostTable()
        {
            Console.WriteLine("ТАБУЛЮВАННЯ ЦІНИ АВТОМОБІЛЯ");
            Console.WriteLine($"{"Пробіг, тис.км",15} | {"Ціна, тис.$",12}");
            Console.WriteLine(new string('-', 30));

            double from = 0.0;
            double to = 100.0;
            double step = 20.0;
            double initialPrice = 35.0;

            for (double km = from; km <= to + 1e-9; km += step)
            {
                double price = initialPrice * Math.Exp(-0.0048 * km);
                Console.WriteLine($"{km,15:F1} | {price,12:F2}");
            }
        }

        static void ShowWorkloadTable()
        {
            Console.Write("Введіть кількість рядків (від 1 до 5): ");
            if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0 || rows > 5)
            {
                Console.WriteLine("Помилка: невірне число рядків (дозволено від 1 до 5).");
                return;
            }
            Console.Write("Введіть кількість стовпців (від 1 до 5): ");
            if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0 || cols > 5)
            {
                Console.WriteLine("Помилка: невірне число стовпців (дозволено від 1 до 5).");
                return;
            }

            Console.WriteLine("\nЗВЕДЕНА ТАБЛИЦЯ ПРОДАЖУ ТА ПІДСУМКИ");
            Console.Write($"{"Модель",10}");
            for (int col = 1; col <= cols; col++)
            {
                Console.Write($"{'М' + col.ToString(),10}");
            }
            Console.WriteLine($"{"Разом",10}");
            Console.WriteLine(new string('-', 10 + (cols + 1) * 10));

            int totalSum = 0;
            for (int r = 1; r <= rows; r++)
            {
                Console.Write($"{"Серія " + r,10}");
                int rowSum = 0;
                for (int c = 1; c <= cols; c++)
                {
                    int soldCount = r * c; 
                    rowSum += soldCount;
                    Console.Write($"{soldCount,10}");
                }

                totalSum += rowSum;
                Console.WriteLine($"{rowSum,10}"); 
            }

            Console.WriteLine(new string('-', 10 + (cols + 1) * 10));
            Console.WriteLine($"Загалом продано машин: {totalSum}");
        }
        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}