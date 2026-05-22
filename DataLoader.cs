using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace CourseProject
{
    internal class DataLoader
    {
        private readonly HttpClient client = new HttpClient();

        private readonly Dictionary<int, string> files = new()
        {
            { 1958, "https://info.toto.bg/content/files/stats-tiraji/649_58.txt" },
            { 1959, "https://info.toto.bg/content/files/stats-tiraji/649_59.txt" },
            { 1960, "https://info.toto.bg/content/files/stats-tiraji/649_60.txt" },
            { 1961, "https://info.toto.bg/content/files/stats-tiraji/649_61.txt" },
            { 1962, "https://info.toto.bg/content/files/stats-tiraji/649_62.txt" },
            { 1963, "https://info.toto.bg/content/files/stats-tiraji/649_63.txt" },
            { 1964, "https://info.toto.bg/content/files/stats-tiraji/649_64.txt" },
            { 1965, "https://info.toto.bg/content/files/stats-tiraji/649_65.txt" },
            { 1966, "https://info.toto.bg/content/files/stats-tiraji/649_66.txt" },
            { 1967, "https://info.toto.bg/content/files/stats-tiraji/649_67.txt" },
            { 1968, "https://info.toto.bg/content/files/stats-tiraji/649_68.txt" },
            { 1969, "https://info.toto.bg/content/files/stats-tiraji/649_69.txt" },
            { 1970, "https://info.toto.bg/content/files/stats-tiraji/649_70.txt" },
            { 1971, "https://info.toto.bg/content/files/stats-tiraji/649_71.txt" },
            { 1972, "https://info.toto.bg/content/files/stats-tiraji/649_72.txt" },
            { 1973, "https://info.toto.bg/content/files/stats-tiraji/649_73.txt" },
            { 1974, "https://info.toto.bg/content/files/stats-tiraji/649_74.txt" },
            { 1975, "https://info.toto.bg/content/files/stats-tiraji/649_75.txt" },
            { 1976, "https://info.toto.bg/content/files/stats-tiraji/649_76.txt" },
            { 1977, "https://info.toto.bg/content/files/stats-tiraji/649_77.txt" },
            { 1978, "https://info.toto.bg/content/files/stats-tiraji/649_78.txt" },
            { 1979, "https://info.toto.bg/content/files/stats-tiraji/649_79.txt" },
            { 1980, "https://info.toto.bg/content/files/stats-tiraji/649_80.txt" },
            { 1981, "https://info.toto.bg/content/files/stats-tiraji/649_81.txt" },
            { 1982, "https://info.toto.bg/content/files/stats-tiraji/649_82.txt" },
            { 1983, "https://info.toto.bg/content/files/stats-tiraji/649_83.txt" },
            { 1984, "https://info.toto.bg/content/files/stats-tiraji/649_84.txt" },
            { 1985, "https://info.toto.bg/content/files/stats-tiraji/649_85.txt" },
            { 1986, "https://info.toto.bg/content/files/stats-tiraji/649_86.txt" },
            { 1987, "https://info.toto.bg/content/files/stats-tiraji/649_87.txt" },
            { 1988, "https://info.toto.bg/content/files/stats-tiraji/649_88.txt" },
            { 1989, "https://info.toto.bg/content/files/stats-tiraji/649_89.txt" },
            { 1990, "https://info.toto.bg/content/files/stats-tiraji/649_90.txt" },
            { 1991, "https://info.toto.bg/content/files/stats-tiraji/649_91.txt" },
            { 1992, "https://info.toto.bg/content/files/stats-tiraji/649_92.txt" },
            { 1993, "https://info.toto.bg/content/files/stats-tiraji/649_93.txt" },
            { 1994, "https://info.toto.bg/content/files/stats-tiraji/649_94.txt" },
            { 1995, "https://info.toto.bg/content/files/stats-tiraji/649_95.txt" },
            { 1996, "https://info.toto.bg/content/files/stats-tiraji/649_96.txt" },
            { 1997, "https://info.toto.bg/content/files/stats-tiraji/649_97.txt" },
            { 1998, "https://info.toto.bg/content/files/stats-tiraji/649_98.txt" },
            { 1999, "https://info.toto.bg/content/files/stats-tiraji/649_99.txt" },
            { 2000, "https://info.toto.bg/content/files/stats-tiraji/649_00.txt" },
            { 2001, "https://info.toto.bg/content/files/stats-tiraji/649_01.txt" },
            { 2002, "https://info.toto.bg/content/files/stats-tiraji/649_02.txt" },
            { 2003, "https://info.toto.bg/content/files/stats-tiraji/649_03.txt" },
            { 2004, "https://info.toto.bg/content/files/stats-tiraji/649_04.txt" },
            { 2005, "https://info.toto.bg/content/files/stats-tiraji/649_2005.txt" },
            { 2006, "https://info.toto.bg/content/files/stats-tiraji/649_2006.txt" },
            { 2007, "https://info.toto.bg/content/files/stats-tiraji/649_2007.txt" },
            { 2008, "https://info.toto.bg/content/files/stats-tiraji/649_2008.txt" },
            { 2009, "https://info.toto.bg/content/files/stats-tiraji/649_2009.txt" },
            { 2010, "https://info.toto.bg/content/files/stats-tiraji/649_2010.txt" },
            { 2011, "https://info.toto.bg/content/files/stats-tiraji/649_2011.txt" },
            { 2012, "https://info.toto.bg/content/files/stats-tiraji/649_2012.txt" },
            { 2013, "https://info.toto.bg/content/files/stats-tiraji/649_2013.txt" },
            { 2014, "https://info.toto.bg/content/files/stats-tiraji/649_2014.txt" },
            { 2015, "https://info.toto.bg/content/files/stats-tiraji/649_2015.txt" },
            { 2016, "https://info.toto.bg/content/files/stats-tiraji/649_2016.txt" },
            { 2017, "https://info.toto.bg/content/files/2018/01/26/2a0952991d371ca5575a4d79e5c5e5d5.txt"},
            { 2018, "https://info.toto.bg/content/files/2019/02/16/be9d1b15257f53cd749db1e501b01180.txt"},
            { 2019, "https://info.toto.bg/content/files/2020/01/04/149bdb98aa8426faf31b8b57fde4c5eb.txt"},
            { 2020, "https://info.toto.bg/content/files/2021/01/09/8241c0de420163c1fcfd616689d1fa33.txt"},
            { 2021, "https://info.toto.bg/content/files/2022/01/02/b72d0cbe449bcc17ec8ecb19ee82233a.docx"},
            { 2022, "https://info.toto.bg/content/files/2023/01/11/5f8be78ee5e2ceb7839cefe22b7d2f1b.docx"},
            { 2023, "https://info.toto.bg/content/files/2024/01/08/c6283cfbdeb917bb3ba894cc38b24728.docx"},
            { 2024, "https://info.toto.bg/content/files/2025/01/06/ea7643fc1635991fe4548cf57b3cf994.docx"},
            { 2025, "https://info.toto.bg/content/files/2026/01/07/5026e066d4883844db5c8ab602e38858.docx"}
        };

        public IEnumerable<Draw> LoadData()
        {
            var result = new List<Draw>();

            foreach (var file in files)
            {
                int year = file.Key;
                string url = file.Value;
                try
                {
                    string content;

                    if (url.EndsWith(".docx"))
                    {
                        content = ReadDocx(url);
                        content = FormatDocx(content);
                    }
                    else
                    {
                        content = client.GetStringAsync(url).Result;
                    }

                    result.AddRange(Parse(content, year));
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return result;
        }

        private IEnumerable<Draw> Parse(string content, int year)
        {
            if (year < 2018)
                return ParseLegacy(content, year);

            return ParseModern(content, year);
        }

        private IEnumerable<Draw> ParseLegacy(string content, int year)
        {
            var result = new List<Draw>();

            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var numbers = Regex.Matches(line, @"\d+")
                    .Select(m => int.Parse(m.Value))
                    .ToList();

                if (numbers.Count < 7)
                    continue;

                result.Add(new Draw
                {
                    Year = year,
                    Pull = numbers[0],
                    Numbers = numbers.Skip(1).Take(6).ToList()
                });

                if (numbers.Count >= 13)
                {
                    result.Add(new Draw
                    {
                        Year = year,
                        Pull = numbers[0],
                        Numbers = numbers.Skip(7).Take(6).ToList()
                    });
                }
            }

            return result;
        }

        private IEnumerable<Draw> ParseModern(string content, int year)
        {
            var result = new List<Draw>();
            var lines = SplitLines(content);

            foreach (var line in lines)
            {
                if (!IsValidDrawLine(line))
                    continue;

                var pull = ExtractPull(line);
                var numbers = ExtractNumbers(line);

                if (numbers.Count < 6)
                    continue;

                result.Add(new Draw
                {
                    Year = year,
                    Pull = pull,
                    Numbers = numbers.TakeLast(6).ToList()
                });
            }

            return result;
        }

        private string ReadDocx(string url)
        {
            var bytes = client.GetByteArrayAsync(url).Result;

            using var stream = new MemoryStream(bytes);
            using var doc = WordprocessingDocument.Open(stream, false);

            return doc.MainDocumentPart?.Document?.Body?.InnerText ?? "";
        }

        private string FormatDocx(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return string.Empty;

            var startIndex = content.IndexOf("Тираж", StringComparison.Ordinal);
            if (startIndex >= 0)
                content = content[startIndex..];

            content = Regex.Replace(content, @"\s+", " ");

            content = content.Replace("Тираж", "\nТираж");

            content = content
                .Replace("\r", "")
                .Replace("\n ", "\n")
                .Trim();

            return content;
        }

        private IEnumerable<string> SplitLines(string content)
        {
            return content
                .Replace("\r", "")
                .Split('\n', StringSplitOptions.RemoveEmptyEntries);
        }

        private bool IsValidDrawLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return false;

            var numbers = Regex.Matches(line, @"\d+")
                .Select(m => int.Parse(m.Value))
                .ToList();

            var validLottoNumbers = numbers.Count(n => n >= 1 && n <= 49);

            return validLottoNumbers >= 6;
        }

        private int ExtractPull(string line)
        {
            var match = Regex.Match(line, @"тираж\s*(\d+)", RegexOptions.IgnoreCase);

            if (match.Success)
                return int.Parse(match.Groups[1].Value);

            var numbers = Regex.Matches(line, @"\d+")
                .Select(m => int.Parse(m.Value))
                .ToList();

            return numbers.FirstOrDefault(n => n > 0);
        }

        private List<int> ExtractNumbers(string line)
        {
            return Regex.Matches(line, @"\d+")
                .Select(m => int.Parse(m.Value))
                .Where(n => n >= 1 && n <= 49)
                .ToList();
        }
    }
}