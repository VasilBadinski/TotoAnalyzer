using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject
{
    internal class Processor
    {
        private readonly DataLoader loader;

        private bool periodSelected = false;
        private int fromYear;
        private int toYear;

        private Statistics statistics;
        private Visualizer visualizer;

        private Task<Statistics> statisticsTask;

        public Processor()
        {
            loader = new DataLoader();
        }

        public void Run()
        {
            visualizer = new Visualizer();

            statisticsTask = Task.Run(() =>
            {
                IEnumerable<Draw> data = loader.LoadData();
                return new Statistics(data);
            });

            while (true)
            {
                Console.Clear();

                PrintMenu();

                Console.Write(" Избор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ExecuteWhenReady(SelectPeriod);
                        break;

                    case "2":
                        ExecuteWhenReady(ShowTopNumbers);
                        break;

                    case "3":
                        ExecuteWhenReady(ShowHotPairs);
                        break;

                    case "4":
                        ExecuteWhenReady(ShowDistribution);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невалиден избор!");
                        Pause();
                        break;
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("             ТОТО АНАЛИЗАТОР");
            Console.WriteLine("============================================");
            Console.WriteLine(" [1] Избери период (от година - до година)");
            Console.WriteLine(" [2] Топ N най-чести числа");
            Console.WriteLine(" [3] Горещи двойки");
            Console.WriteLine(" [4] Разпределение по десетици");
            Console.WriteLine();
            Console.WriteLine(" [0] Изход");
            Console.WriteLine("============================================");

            if (periodSelected)
            {
                Console.WriteLine($" Избран период: {fromYear} - {toYear}");
                Console.WriteLine("============================================");
            }
        }

        private void SelectPeriod()
        {
            try
            {
                Console.Write("От година: ");
                fromYear = int.Parse(Console.ReadLine());

                Console.Write("До година: ");
                toYear = int.Parse(Console.ReadLine());

                if (fromYear > toYear)
                {
                    Console.WriteLine("Грешка: началната година е по-голяма от крайната!");
                    periodSelected = false;
                }
                else
                {
                    periodSelected = true;
                    Console.WriteLine("Периодът е успешно зададен!");
                }
            }
            catch
            {
                Console.WriteLine("Невалиден вход! Въведи числа.");
                periodSelected = false;
            }

            Pause();
        }

        private bool RequirePeriod()
        {
            if (!periodSelected)
            {
                Console.WriteLine("Първо трябва да избереш период!");
                Pause();
                return false;
            }

            return true;
        }

        private void ShowTopNumbers()
        {
            if (!RequirePeriod())
                return;

            Console.Write("Въведи N: ");

            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Невалидно число!");
                Pause();
                return;
            }

            var topNumbers = statistics.TopNumbers(fromYear, toYear, n);

            Console.WriteLine();
            Console.WriteLine($"Топ {n} най-чести числа ({fromYear}-{toYear})");
            Console.WriteLine();

            visualizer.PrintBarChart(topNumbers);

            Pause();
        }

        private void ShowHotPairs()
        {
            if (!RequirePeriod())
                return;

            Console.Write("Въведи N: ");

            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Невалидно число!");
                Pause();
                return;
            }

            var pairs = statistics.HotPairs(fromYear, toYear, n);

            Console.WriteLine();
            Console.WriteLine($"Топ {n} горещи двойки ({fromYear}-{toYear})");
            Console.WriteLine();

            foreach (var pair in pairs)
            {
                Console.WriteLine(
                    $"{pair.Item1} + {pair.Item2} -> {pair.Item3} пъти");
            }

            Pause();
        }

        private void ShowDistribution()
        {
            if (!RequirePeriod())
                return;

            var distribution =
                statistics.DistributionByTens(fromYear, toYear);

            Console.WriteLine();
            Console.WriteLine(
                $"Разпределение по десетици ({fromYear}-{toYear})");
            Console.WriteLine();

            foreach (var item in distribution)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            Console.WriteLine();
            visualizer.PrintHeatMap(
                statistics.GetAllNumberCounts(fromYear, toYear));

            Pause();
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Натисни клавиш за връщане към меню...");
            Console.ReadKey();
        }

        private void ExecuteWhenReady(Action action)
        {
            if (!statisticsTask.IsCompleted)
            {
                Console.WriteLine("Моля изчакайте, данните още се зареждат...");
                Pause();
                return;
            }

            statistics ??= statisticsTask.Result;

            action();
        }
    }
}