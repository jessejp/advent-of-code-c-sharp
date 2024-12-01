using Xunit;
namespace AOC2024;

public class Day1
{

    public IEnumerable<List<int>> setLocationIDsIntoLists(string[] input)
    {
        List<int> leftList = [];
        List<int> rightList = [];
        foreach (string loc in input)
        {
            var splitted = loc.Split("   ");
            if (splitted.Length == 2)
            {
                int left;
                int right;
                if (int.TryParse(splitted[0], out left))
                {
                    leftList.Add(left);
                }
                if (int.TryParse(splitted[1], out right))
                {
                    rightList.Add(right);
                }
                // Console.WriteLine($"initial {left}, {right}");
            }
        }

        return [leftList, rightList];
    }

    public List<int> BubbleSort(List<int> list)
    {
        for (int i = 0; i < list.ToArray().Length; i++)
        {
            for (int j = 0; j < list.ToArray().Length - 1 - i; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int greater = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = greater;
                }
            }
        }
        return list;
    }

    public int CalculateDifferenceSum(int[] left, int[] right)
    {
        List<int> diff = [];
        for (int i = 0; i < left.Length; i++)
        {
            int difference = int.Abs(left[i] - right[i]);
            // Console.WriteLine($"({i}) diff: {left[i]}-{right[i]}={difference}");
            diff.Add(difference);
        }
        return diff.Sum();
    }

    [Fact]
    [Trait("Day1", "Example")]
    public void Example()
    {
        string[] input = Utility.GetInput("example", "day1.txt");
        var lists = setLocationIDsIntoLists(input);
        var sortedLeft = BubbleSort(lists.ToArray()[0]);
        var sortedRight = BubbleSort(lists.ToArray()[1]);

        Assert.Equal(11, CalculateDifferenceSum(sortedLeft.ToArray(), sortedRight.ToArray()));
    }

    [Fact]
    [Trait("Day1", "Example_Part2")]
    public void Example_Part2()
    {
        string[] input = Utility.GetInput("example", "day1.txt");
        var lists = setLocationIDsIntoLists(input);
        var left = lists.ToArray()[0];
        var right = lists.ToArray()[1];

        int similarityScore = 0;
        foreach (int num in left)
        {
            similarityScore += right.Where(r => r == num).Sum();
        }

        Assert.Equal(31, similarityScore);
    }

    [Fact]
    [Trait("Day1", "Solution_Part2")]
    public void Solution_Part2()
    {
        string[] input = Utility.GetInput("input", "day1.txt");
        var lists = setLocationIDsIntoLists(input);
        var left = lists.ToArray()[0];
        var right = lists.ToArray()[1];

        int similarityScore = 0;
        foreach (int num in left)
        {
            similarityScore += right.Where(r => r == num).Sum();
        }

        Assert.Equal(22539317, similarityScore);
    }

    [Fact]
    [Trait("Day1", "Solution")]
    public void Solution()
    {
        string[] input = Utility.GetInput("input", "day1.txt");
        var lists = setLocationIDsIntoLists(input);
        var sortedLeft = BubbleSort(lists.ToArray()[0]);
        var sortedRight = BubbleSort(lists.ToArray()[1]);
        Assert.Equal(1941353, CalculateDifferenceSum(sortedLeft.ToArray(), sortedRight.ToArray()));
    }
}
