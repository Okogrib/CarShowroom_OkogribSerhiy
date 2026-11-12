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

                if (choice == "0")
                {
                    running = false;
                    Console.WriteLine("До побачення.");
                }
                else
                {
                    Console.WriteLine("Пункт ще не реалізовано.");
                }
            }
        }
    }
}