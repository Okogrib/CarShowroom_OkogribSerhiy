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
                        Console.WriteLine("Поки не зроблено.");
                        Pause();
                        break;
                    case "3":
                        Console.WriteLine("Поки не зроблено.");
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
            Console.WriteLine("Тема: Автосалон");
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

        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}