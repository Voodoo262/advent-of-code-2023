// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

var tasks = new List<Task<string>>();

///
/// Day 1 - Part 1
/// 
tasks.Add(Task.Run(() =>
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
    return $"Day 1 - Part 1: {sum}";
}));

///
/// Day 1 - Part 2
/// 
tasks.Add(Task.Run(() =>
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
    return $"Day 1 - Part 2: {sum}";
}));

///
/// Day 2 - Part 1
/// 
tasks.Add(Task.Run(() =>
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
    return $"Day 2 - Part 1: {sum}";
}));

///
/// Day 2 - Part 2
/// 
tasks.Add(Task.Run(() =>
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
    return $"Day 2 - Part 2: {sum}";
}));

///
/// Day 3 - Part 1
/// 
tasks.Add(Task.Run(() =>
{
    Func<char, bool> isSymbol = (char character) => !char.IsDigit(character) && character != '.';
    Func<string[], int, int, int, bool> hasAdjacentChar = (string[] lines, int lineNumber, int startChar, int endChar) =>
    {
        if (lineNumber > 0)
        {
            for (int col = Math.Max(0, startChar - 1); col <= Math.Min(endChar + 1, lines.Length - 1); col++)
            {
                if (isSymbol(lines[lineNumber - 1][col])) return true;
            }
        }
        if (startChar > 0 && isSymbol(lines[lineNumber][startChar - 1])) return true;
        if (endChar < lines[lineNumber].Length - 1 && isSymbol(lines[lineNumber][endChar + 1])) return true;
        if (lineNumber < lines.Length - 1)
        {
            for (int col = Math.Max(0, startChar - 1); col <= Math.Min(endChar + 1, lines.Length - 1); col++)
            {
                if (isSymbol(lines[lineNumber + 1][col])) return true;
            }
        }
        return false;
    };
    int sum = 0;
    string[] lines = File.ReadAllLines(Path.Combine("PuzzleInput", "day03.txt"));
    for (int lineNumber = 0; lineNumber < lines.Length; lineNumber++)
    {
        string line = lines[lineNumber];
        for (int startChar = 0; startChar < line.Length; startChar++)
        {
            if (char.IsDigit(line[startChar]))
            {
                int endChar = startChar + 1;
                for (; endChar < line.Length; endChar++)
                {
                    if (!char.IsDigit(line[endChar]))
                    {
                        break;
                    }
                }
                int numberLength = endChar - startChar;
                if (hasAdjacentChar(lines, lineNumber, startChar, endChar - 1))
                {
                    int number = int.Parse(line.Substring(startChar, numberLength));
                    sum += number;
                }
                startChar += numberLength;
            }
        }
    }
    return $"Day 3 - Part 1: {sum}";
}));

Task.WaitAll(tasks.ToArray());

// Print output of each task
foreach (var task in tasks)
{
    var result = await task;
    Console.WriteLine(result);
}
