namespace AoC2015;

public class Reader
{
    public static TextReader GetReader(int riddleNumber)
    {
        const string path = "/home/toohka/Documents/DEV/AdventOfCode/AoC2015/inputs/input_";
        return new StreamReader(Path.Combine(path, riddleNumber.ToString(), ".in"));
    }

}