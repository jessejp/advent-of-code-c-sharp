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
        ReportResult result = ReportResult.Undecided;

        for (int i = 1; i < report.Length; i++)
        {
            int diff = int.Abs(report[i - 1] - report[i]);
            // Console.WriteLine($"i: {report[i - 1]}-{report[i]} diff {diff}");
            if (diff > maxDataDiffer || diff < minDataDiffer)
            {
                result = ReportResult.Unsafe;
                break;
            }
            else if (((i > 1 && result == ReportResult.AllIncreasing) || i == 1) && report[i] > report[i - 1])
            {
                result = ReportResult.AllIncreasing;
            }
            else if (((i > 1 && result == ReportResult.AllDecreasing) || i == 1) && report[i] < report[i - 1])
            {
                result = ReportResult.AllDecreasing;
            }
            else
            {
                result = ReportResult.Unsafe;
                break;
            }
        }

        return result;
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
