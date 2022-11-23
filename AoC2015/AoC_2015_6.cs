namespace AoC2015;

public class AoC_2015_6
{
    public static double Riddle6()
    {
        var instructions = new List<Instruction>();
        try
        {
            //using TextReader reader = new StreamReader(path);
            using var reader = Reader.GetReader(6);

            while (reader.ReadLine() is { } line)
            {
                instructions.Add(ProcessLine(line));
            }
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Readfile not found!");
        }

        return CountLights(LightMatrix(instructions));
    }

    private static Instruction ProcessLine(string line)
    {
        var splitline = line.Split(' ');
        var tokens = new Queue<string>();

        foreach (var token in splitline)
        {
            tokens.Enqueue(token);
        }

        int action;


        if (tokens.Dequeue() == "turn")
        {
            action = tokens.Dequeue() == "on" ? 1 : 0;
        }
        else
        {
            action = 2; //Toggle <=> 2
        }

        var startCoords = tokens.Dequeue().Split(',');
        var start = new Coordinates(int.Parse(startCoords[0]), int.Parse(startCoords[1]));
        tokens.Dequeue(); //Dequeue "through"
        var endCoords = tokens.Dequeue().Split(',');
        var end = new Coordinates(int.Parse(endCoords[0]), int.Parse(endCoords[1]));

        return new Instruction(action, start, end);
    }

    private static bool[,] LightMatrix(List<Instruction> instructions)
    {
        var grid = new bool[1000, 1000];

        foreach (var inst in instructions)
        {
            for (int x = inst.Start.X; x <= inst.End.X; x++)
            {
                for (int y = inst.Start.Y; y <= inst.End.Y; y++)
                {
                    grid[x, y] = inst.Action switch
                    {
                        0 => false,
                        1 => true,
                        _ => !grid[x, y]
                    };
                }
            }
        }

        return grid;
    }

    private static double CountLights(bool[,] grid)
    {
        double onCount = 0;
        foreach (var light in grid)
        {
            if (light == true)
                onCount++;
        }

        return onCount;
    }
}

public class Coordinates
{
    public int X { get; }
    public int Y { get; }
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Instruction
{
    public int Action { get; }
    public Coordinates Start { get; }
    public Coordinates End { get; }
    public Instruction(int action, Coordinates start, Coordinates end)
    {
        Action = action;
        Start = start;
        End = end;
    }
}