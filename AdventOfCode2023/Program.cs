// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

/// Day 1 - Part 1
{
    int sum = 0;
    foreach (string line in File.ReadAllLines(Path.Combine("PuzzleInput", "day01.txt")))
    {
        char? firstDigit = null;
        char? lastDigit = null;
        foreach (char c in line.ToCharArray())
        {
            if (char.IsDigit(c))
            {
                if (!firstDigit.HasValue)
                {
                    firstDigit = lastDigit = c;
                }
                else
                {
                    lastDigit = c;
                }
            }
        }
        sum += 10 * (int)char.GetNumericValue(firstDigit ?? '0') + (int)char.GetNumericValue(lastDigit ?? '0');
    }
    Console.WriteLine($"Day 1 - Part 1: {sum}");
}

/// Day 1 - Part 2
{
    int sum = 0;
    foreach (string line in File.ReadAllLines(Path.Combine("PuzzleInput", "day01.txt")))
    {
        char? firstDigit = null;
        char? lastDigit = null;
        for (int i = 0; i < line.Length; i++)
        {
            char? curDigit = null;
            char c = line.ToCharArray()[i];
            if (char.IsDigit(c))
            {
                if (!firstDigit.HasValue)
                {
                    curDigit = c;
                }
                else
                {
                    curDigit = c;
                }
            }
            else
            {
                string remainder = line.Substring(i);
                if (remainder.StartsWith("one"))
                {
                    curDigit = '1';
                }
                else if (remainder.StartsWith("two"))
                {
                    curDigit = '2';
                }
                else if (remainder.StartsWith("three"))
                {
                    curDigit = '3';
                }
                else if (remainder.StartsWith("four"))
                {
                    curDigit = '4';
                }
                else if (remainder.StartsWith("five"))
                {
                    curDigit = '5';
                }
                else if (remainder.StartsWith("six"))
                {
                    curDigit = '6';
                }
                else if (remainder.StartsWith("seven"))
                {
                    curDigit = '7';
                }
                else if (remainder.StartsWith("eight"))
                {
                    curDigit = '8';
                }
                else if (remainder.StartsWith("nine"))
                {
                    curDigit = '9';
                }
                else if (remainder.StartsWith("zero"))
                {
                    curDigit = '0';
                }
            }
            if (curDigit.HasValue)
            {
                if (!firstDigit.HasValue)
                {
                    firstDigit = lastDigit = curDigit;
                }
                else
                {
                    lastDigit = curDigit;
                }
            }
        }
        sum += 10 * (int)char.GetNumericValue(firstDigit ?? '0') + (int)char.GetNumericValue(lastDigit ?? '0');
    }
    Console.WriteLine($"Day 1 - Part 2: {sum}");
}

/// Day 2 - Part 1
{
    int sum = 0;
    foreach (string line in File.ReadAllLines(Path.Combine("PuzzleInput", "day02.txt")))
    {
        int colonPos = line.IndexOf(':');
        int dayNumber = int.Parse(line.Substring(0, colonPos).Split(' ')[1]);
        int redCount = 0;
        int greenCount = 0;
        int blueCount = 0;
        foreach (string hand in line.Trim().Split(';'))
        {
            foreach (Match m in Regex.Matches(hand, "(\\d+) (red|green|blue)"))
            {
                int cubeCount = int.Parse(m.Groups[1].Value);
                string cubeColor = m.Groups[2].Value;
                switch (cubeColor)
                {
                    case "red":
                        redCount = Math.Max(redCount, cubeCount);
                        break;
                    case "green":
                        greenCount = Math.Max(greenCount, cubeCount);
                        break;
                    case "blue":
                        blueCount = Math.Max(blueCount, cubeCount);
                        break;
                    default:
                        throw new InvalidDataException("invalid color " + cubeColor);
                }
            }
        }
        if (redCount <= 12 && greenCount <= 13 && blueCount <= 14)
        {
            sum += dayNumber;
        }
    }
    Console.WriteLine($"Day 2 - Part 1: {sum}");
}

/// Day 2 - Part 2
{
    int sum = 0;
    foreach (string line in File.ReadAllLines(Path.Combine("PuzzleInput", "day02.txt")))
    {
        int colonPos = line.IndexOf(':');
        int dayNumber = int.Parse(line.Substring(0, colonPos).Split(' ')[1]);
        int redCount = 0;
        int greenCount = 0;
        int blueCount = 0;
        foreach (string hand in line.Trim().Split(';'))
        {
            foreach (Match m in Regex.Matches(hand, "(\\d+) (red|green|blue)"))
            {
                int cubeCount = int.Parse(m.Groups[1].Value);
                string cubeColor = m.Groups[2].Value;
                switch (cubeColor)
                {
                    case "red":
                        redCount = Math.Max(redCount, cubeCount);
                        break;
                    case "green":
                        greenCount = Math.Max(greenCount, cubeCount);
                        break;
                    case "blue":
                        blueCount = Math.Max(blueCount, cubeCount);
                        break;
                    default:
                        throw new InvalidDataException("invalid color " + cubeColor);
                }
            }
        }
        sum += redCount * greenCount * blueCount;
    }
    Console.WriteLine($"Day 2 - Part 2: {sum}");
}