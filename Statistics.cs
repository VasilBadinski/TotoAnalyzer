using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProject
{
    internal class Statistics
    {
        private readonly IEnumerable<Draw> draws;

        public Statistics(IEnumerable<Draw> draws)
        {
            this.draws = draws;
        }

        public Dictionary<int, int> TopNumbers(int n)
        {
            return draws
                .SelectMany(d => d.Numbers)
                .GroupBy(x => x)
                .Select(g => new { Number = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(n)
                .ToDictionary(x => x.Number, x => x.Count);
        }

        public List<(int, int, int)> HotPairs(int n)
        {
            return draws
                .SelectMany(d => d.Numbers
                    .OrderBy(x => x)
                    .SelectMany((x, i) =>
                        d.Numbers
                            .OrderBy(y => y)
                            .Skip(i + 1)
                            .Select(y => (A: x, B: y))
                    ))
                .GroupBy(p => p)
                .Select(g => (g.Key.A, g.Key.B, g.Count()))
                .OrderByDescending(x => x.Item3)
                .Take(n)
                .ToList();
        }

        public Dictionary<string, int> DistributionByTens()
        {
            return draws
                .SelectMany(d => d.Numbers)
                .GroupBy(n => GetRange(n))
                .Select(g => new { Range = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Range, x => x.Count);
        }

        private string GetRange(int number)
        {
            if (number <= 10) return "1-10";
            if (number <= 20) return "11-20";
            if (number <= 30) return "21-30";
            if (number <= 40) return "31-40";
            return "41-49";
        }

        private IEnumerable<Draw> FilterByPeriod(int fromYear, int toYear)
        {
            return draws.Where(d =>
                d.Year >= fromYear &&
                d.Year <= toYear);
        }

        public Dictionary<int, int> TopNumbers(
            int fromYear,
            int toYear,
            int n)
        {
            return FilterByPeriod(fromYear, toYear)
                .SelectMany(d => d.Numbers)
                .GroupBy(x => x)
                .Select(g => new
                {
                    Number = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(n)
                .ToDictionary(x => x.Number, x => x.Count);
        }

        public List<(int, int, int)> HotPairs(
            int fromYear,
            int toYear,
            int n)
        {
            return FilterByPeriod(fromYear, toYear)
                .SelectMany(d => d.Numbers
                    .OrderBy(x => x)
                    .SelectMany((x, i) =>
                        d.Numbers
                            .OrderBy(y => y)
                            .Skip(i + 1)
                            .Select(y => (A: x, B: y))
                    ))
                .GroupBy(p => p)
                .Select(g => (
                    g.Key.A,
                    g.Key.B,
                    g.Count()))
                .OrderByDescending(x => x.Item3)
                .Take(n)
                .ToList();
        }

        public Dictionary<string, int> DistributionByTens(
            int fromYear,
            int toYear)
        {
            return FilterByPeriod(fromYear, toYear)
                .SelectMany(d => d.Numbers)
                .GroupBy(n => GetRange(n))
                .Select(g => new
                {
                    Range = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.Range, x => x.Count);
        }

        public Dictionary<int, int> GetAllNumberCounts(
            int fromYear,
            int toYear)
        {
            return FilterByPeriod(fromYear, toYear)
                .SelectMany(d => d.Numbers)
                .GroupBy(n => n)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
