using System.Collections.Immutable;
using Xunit;
namespace AOC2024;

public class Day2
{

    public enum ReportResult
    {
        Undecided,
        AllIncreasing,
        AllDecreasing,
        Unsafe
    }

    const int maxDataDiffer = 3;
    const int minDataDiffer = 1;

    public IEnumerable<List<int>> GetReports(string[] input)
    {
        List<List<int>> data = [];
        for (int i = 0; i < input.ToArray().Length; i++)
        {
            data.Add([]);
            var item = input[i];
            foreach (string point in item.Split(" "))
            {
                data[i].Add(int.Parse(point));
            }
        }
        return data;
    }

    public ReportResult CheckReportResult(ImmutableArray<int> report)
    {
        List<ReportResult> results = [];

        for (int i = 1; i < report.Length; i++)
        {
            int diff = int.Abs(report[i - 1] - report[i]);
            // Console.WriteLine($"i: {report[i - 1]}-{report[i]} diff {diff}");
            Console.WriteLine(results.ToArray().Length);
            if (diff > maxDataDiffer || diff < minDataDiffer)
            {
                results.Add(ReportResult.Unsafe);
                Console.WriteLine(results.ToArray()[i - 1]);
                break;
            }
            else if (report[i] > report[i - 1])
            {
                results.Add(ReportResult.AllIncreasing);
            }
            else if (report[i] < report[i - 1])
            {
                results.Add(ReportResult.AllDecreasing);
            }
            else
            {
                results.Add(ReportResult.Unsafe);
                break;
            }
        }
        var types = results.GroupBy(result => result).Select(group => new { Result = group.Key, Count = group.Count() }).OrderBy((o) => o.Count);
        if (types.Count() == 2 && types.Last().Count == 1)
        {
            return types.First().Result;
        }
        else if (types.Count() == 1)
        {
            return results.First();
        } else {
            return ReportResult.Unsafe;
        }
    }

    [Fact]
    [Trait("Day2", "Example")]
    public void Day2Example()
    {
        string[] input = Utility.GetInput("example", "day2.txt");
        var parsedList = GetReports(input);
        List<ReportResult> resultsList = [];
        foreach (var report in parsedList)
        {
            var r = CheckReportResult(report.ToImmutableArray());
            Console.WriteLine($"{report} = {r}");
            resultsList.Add(r);
        }

        Assert.Equal(2, resultsList.Where((r) => r != ReportResult.Unsafe).Count());
    }

    [Fact]
    [Trait("Day2", "Solve")]
    public void Day2Solve()
    {
        string[] input = Utility.GetInput("input", "day2.txt");
        var parsedList = GetReports(input);
        List<ReportResult> resultsList = [];
        foreach (var report in parsedList)
        {
            var r = CheckReportResult(report.ToImmutableArray());
            Console.WriteLine($"{report} = {r}");
            resultsList.Add(r);
        }

        Assert.Equal(624, resultsList.Where((r) => r != ReportResult.Unsafe).Count());
    }
}
