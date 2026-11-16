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
            const int capacity = 100;
            double[] carPrices = new double[capacity];
            int count = 0;

            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ShowAbout(); Pause(); break;
                    case "2": ShowCostTable(); Pause(); break;
                    case "3": ShowWorkloadTable(); Pause(); break;
                    case "4":
                        double newPrice = ReadDouble("Введіть ціну автомобіля (тис. $, від 1 до 500): ", 1, 500);
                        AddPrice(carPrices, ref count, newPrice, capacity);
                        Console.WriteLine($"Поточна кількість записів у базі: {count}");
                        Pause();
                        break;
                    case "5":
                        PrintPricesTable(carPrices, count);
                        Pause();
                        break;
                    case "6":
                        if (count == 0)
                        {
                            Console.WriteLine("База порожня. Немає елементів для видалення.");
                        }
                        else
                        {
                            PrintPricesTable(carPrices, count);
                            int numberToRemove = ReadInt($"Введіть номер запису для видалення (від 1 до {count}): ", 1, count);
                            RemoveAt(carPrices, ref count, numberToRemove - 1);
                        }
                        Pause();
                        break;
                    case "7":
                        if (count == 0)
                        {
                            Console.WriteLine("База порожня. Неможливо порахувати статистику.");
                        }
                        else
                        {
                            CalculateStatistics(carPrices, count, out double totalSum, out double averagePrice);
                            FindMaxPrice(carPrices, count, out double maxPrice, out int maxNumber);
                            Console.WriteLine("СТАТИСТИКА АВТОСАЛОНУ");
                            Console.WriteLine($"Кількість авто: {count}");
                            Console.WriteLine($"Загальна вартість: {totalSum:F2} тис. $");
                            Console.WriteLine($"Середня ціна авто: {averagePrice:F2} тис. $");
                            Console.WriteLine($"Найдорожчий автомобіль: №{maxNumber} ({maxPrice:F2} тис. $)");
                        }
                        Pause();
                        break;
                    case "0": running = false; Console.WriteLine("Роботу програми завершено. До побачення!"); break;
                    default: Console.WriteLine("Помилка: такого пункту меню не існує. Спробуйте ще раз."); Pause(); break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("АВТОСАЛОН");
            Console.WriteLine("1. Про програму");
            Console.WriteLine("2. Таблиця вартості авто залежно від пробігу");
            Console.WriteLine("3. Зведена таблиця наявності та продажу машин");
            Console.WriteLine("4. Додати ціну автомобіля до бази");
            Console.WriteLine("5. Показати список цін автомобілів");
            Console.WriteLine("6. Видалити ціну за номером");
            Console.WriteLine("7. Показати статистику та найдорожче авто");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть пункт меню: ");
        }

        static void AddPrice(double[] values, ref int count, double newValue, int capacity)
        {
            if (count == capacity)
            {
                Console.WriteLine("Помилка: масив заповнений, місця більше немає.");
                return;
            }
            values[count] = newValue;
            count++;
            Console.WriteLine("Ціну успішно додано.");
        }

        static void RemoveAt(double[] values, ref int count, int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Помилка: неправильний номер елемента. Змін не виконано.");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                values[i] = values[i + 1];
            }

            values[count - 1] = 0;
            count--;
            Console.WriteLine($"Запис №{index + 1} успішно видалено.");
        }

        static void PrintPricesTable(double[] values, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("База цін порожня. Немає даних для виведення.");
                return;
            }

            Console.WriteLine("ПЕРЕЛІК ЦІН АВТОМОБІЛІВ");
            Console.WriteLine($"{"№",5} | {"Ціна, тис.$",15}");
            Console.WriteLine(new string('-', 23));

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1,5} | {values[i],15:F2}");
            }
        }

        static void FindMaxPrice(double[] values, int count, out double maxValue, out int maxNumber)
        {
            if (count <= 0)
            {
                maxValue = 0;
                maxNumber = 0;
                return;
            }

            maxValue = values[0];
            maxNumber = 1;

            for (int i = 1; i < count; i++)
            {
                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                    maxNumber = i + 1;
                }
            }
        }

        static void CalculateStatistics(double[] values, int count, out double sum, out double average)
        {
            sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += values[i];
            }
            average = count > 0 ? sum / count : 0;
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

        static int ReadInt(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"Помилка! Введіть ціле число від {min} до {max}.");
            }
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"Помилка! Введіть число від {min} до {max}.");
            }
        }

        static double CalculatePrice(double initialPrice, double km)
        {
            return initialPrice * Math.Exp(-0.0048 * km);
        }

        static void CalculateAndPrintCostTable(double from, double to, double step)
        {
            Console.WriteLine("ТАБУЛЮВАННЯ ЦІНИ АВТОМОБІЛЯ");
            Console.WriteLine($"{"Пробіг, тис.км",15} | {"Ціна, тис.$",12}");
            Console.WriteLine(new string('-', 30));

            double initialPrice = 35.0;

            for (double km = from; km <= to + 1e-9; km += step)
            {
                double price = CalculatePrice(initialPrice, km);
                Console.WriteLine($"{km,15:F1} | {price,12:F2}");
            }
        }

        static void ShowCostTable()
        {
            double from = ReadDouble("Введіть початковий пробіг (від 0 до 50): ", 0, 50);
            double to = ReadDouble("Введіть кінцевий пробіг (від 50 до 150): ", 50, 150);
            double step = ReadDouble("Введіть крок табулювання (від 5 до 50): ", 5, 50);
            Console.WriteLine();

            CalculateAndPrintCostTable(from, to, step);
        }

        static void ShowWorkloadTable()
        {
            int rows = ReadInt("Введіть кількість рядків (від 1 до 5): ", 1, 5);
            int cols = ReadInt("Введіть кількість стовпців (від 1 до 5): ", 1, 5);

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