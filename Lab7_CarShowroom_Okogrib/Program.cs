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
            Console.Write("Введіть кількість рядків (моделей) від 1 до 5: ");
            if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0 || rows > 5)
            {
                Console.WriteLine("Помилка: невірне число рядків!");
                return;
            }

            Console.Write("Введіть кількість стовпців (періодів) від 1 до 5: ");
            if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0 || cols > 5)
            {
                Console.WriteLine("Помилка: невірне число стовпців!");
                return;
            }

            Console.WriteLine("\nДинамічна зведена таблиця продажу:");
            Console.Write($"{"Модель",10}");
            for (int c = 1; c <= cols; c++)
            {
                Console.Write($"{'P' + c.ToString(),8}");
            }
            Console.WriteLine($"{"Разом",8}");

            for (int r = 1; r <= rows; r++)
            {
                Console.Write($"{'М' + r.ToString(),10}");
                int rowTotal = 0;
                for (int c = 1; c <= cols; c++)
                {
                    int val = r * c * 3;
                    rowTotal += val;
                    Console.Write($"{val,8}");
                }
                Console.WriteLine($"{rowTotal,8}");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}