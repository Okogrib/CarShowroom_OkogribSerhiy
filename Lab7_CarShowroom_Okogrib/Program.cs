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
                Console.WriteLine("0. Вихід ");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Поки не зроблено.");
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

        static void Pause()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}