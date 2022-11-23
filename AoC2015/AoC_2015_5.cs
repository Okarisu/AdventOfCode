namespace AoC2015;

public class AoC_2015_5
{
    public static uint Riddle5()
    {
        const string path = "/home/toohka/Documents/DEV/AdventOfCode/AoC2015/inputs/input_5.in";

        uint niceStringsFound = 0;

        try
        {
            using TextReader reader = new StreamReader(path);
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (CheckString(line))
                    niceStringsFound++;
            }
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Readfile not found!");
        }

        return niceStringsFound;
    }

    private static bool CheckString(string line)
    {
        return CheckVowels(line) && CheckDoublets(line) && CheckNaughties(line);
    }

    private static bool CheckVowels(string line)
    {
        var splitline = line.ToCharArray();
        var vowelsFound = splitline.Count(c => c is 'a' or 'i' or 'e' or 'o' or 'u');
        return vowelsFound >= 3;
    }

    private static bool CheckDoublets(string line)
    {
        List<string> doublets = new List<string>();

        for (var letter = 'a'; letter <= 'z'; letter++)
            doublets.Add(letter.ToString() + letter.ToString());

        return doublets.Any(doublet => line.Contains(doublet));
    }

    private static bool CheckNaughties(string line)
    {
        string[] naughties = {"ab", "cd", "pq", "xy"};
        return !naughties.Any(naughty => line.Contains(naughty));
    }
}