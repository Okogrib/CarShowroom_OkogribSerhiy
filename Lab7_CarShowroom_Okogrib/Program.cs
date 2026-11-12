using System.Text;

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
                Console.WriteLine("3. Зведена таблиця наявності та продажу машин");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");
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
                        Console.WriteLine("До побачення.");
                        break;
                    default:
                        Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
                        Pause();
                        break;
                }
            }
        }

        static void ShowAbout()
        {
            Console.WriteLine("Тема: 16. Автосалон");
            Console.WriteLine("Сутності: Користувач, Автомобіль, Модель (довідник)");
            Console.WriteLine("Поля сутності «Автомобіль» (7 полів):");
            Console.WriteLine("1. VIN — string (ідентифікатор)");
            Console.WriteLine("2. марка — string");
            Console.WriteLine("3. код моделі — int (із довідника)");
            Console.WriteLine("4. рік випуску — int");
            Console.WriteLine("5. пробіг — int");
            Console.WriteLine("6. колір — string");
            Console.WriteLine("7. ціна — double");
            Console.WriteLine("8. чи проданий — bool");
            Console.WriteLine("Підсумкова величина: середня ціна за марками та скільки авто продано за місяць.");
        }

        static void ShowCostTable()
        {
            Console.WriteLine("Таблиця орієнтовної ціни авто залежно від пробігу (у тис. км):");
            Console.WriteLine($"{"Пробіг, тис.км",15}{"Ціна, тис.$",15}");
            Console.WriteLine(new string('-', 32));

            double basePrice = 30.0;
            double from = 0.0;
            double to = 150.0;
            double step = 20.0;

            for (double km = from; km <= to + 1e-9; km += step)
            {
               
                double currentPrice = basePrice * Math.Exp(-0.005 * km);
                Console.WriteLine($"{km,15:F1}{currentPrice,15:F2}");
            }
        }

        static void ShowWorkloadTable()
        {
            Console.WriteLine("Зведена таблиця продажу авто з підсумками:");
            Console.Write($"{"Категорія",12}");
            for (int col = 1; col <= 4; col++)
            {
                Console.Write($"{'Q' + col.ToString(),8}");
            }
            Console.WriteLine($"{"Разом",8}");
            Console.WriteLine(new string('-', 44));

            int totalSum = 0;

            for (int row = 1; row <= 3; row++)
            {
                Console.Write($"{'М' + row.ToString(),12}");
                int rowSum = 0;
                for (int col = 1; col <= 4; col++)
                {
                    int val = row * col;
                    rowSum += val;
                    Console.Write($"{val,8}");
                }
                totalSum += rowSum;
                Console.WriteLine($"{rowSum,8}");
            }
            Console.WriteLine(new string('-', 44));
            Console.WriteLine($"Загалом продано автомобілів: {totalSum}");
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}