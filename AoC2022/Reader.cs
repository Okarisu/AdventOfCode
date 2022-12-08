namespace AoC2022;
public class Reader
{
    public static List<string> Read(string filename)
    {
        var lines = new List<string>();
        const string path = "/home/toohka/Documents/DEV/AdventOfCode/AoC2022/inputs/";
        var reader = new StreamReader(path + filename + ".in");
        
        try
        {
            while (reader.ReadLine() is { } line)
            {
                lines.Add(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return lines;
    }
}