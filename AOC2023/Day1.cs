using Xunit;

namespace AOC2023
{
    public class Day1
    {
        [Fact]
        public void Solve_ExampleInput_ReturnsExpectedOutput()
        {
            // Arrange
            var solver = new Day1Solver();

            var exampleInput = Helper.GetInput("example", "day1_1.txt");

            // Act
            var result = solver.Solve(exampleInput);

            Console.WriteLine($"RESULT ======== {result}");

            // Assert
            Assert.Equal(142, result);
        }

        public class Day1Solver()
        {

            public List<string> Numbers { get; set; } = new List<string>();
            public int Total {get; set;} = 0;

            public int Solve(string[] input)
            {
                foreach (var line in input)
                {
                    // Console.WriteLine(line);
                    var LineNumbers = new List<string>();
                    foreach (var c in line.ToArray())
                    {
                        bool tryPraseResult = int.TryParse($"{c}", out int num);
                        if (tryPraseResult)
                        {
                            LineNumbers.Add(c.ToString());
                        }
                    }
                    string aggregatedLineNumbers = LineNumbers.Aggregate((x, y) => x + y);
                    Console.WriteLine($"LINE: {aggregatedLineNumbers}");
                    Numbers.Add(aggregatedLineNumbers);
                }

                foreach (var num in Numbers)
                {
                    string FirstLast = num.First().ToString() + num.Last();
                    Console.WriteLine($"{num} first last : {FirstLast}");
                    Total += int.Parse(FirstLast);
                }

                return Total;
            }
        }
    }
}
