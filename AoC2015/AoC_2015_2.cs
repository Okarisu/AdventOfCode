namespace AoC2015;

public class AoC_2015_2
{
    public static void Riddle2()
    {
        Queue<string> dimensions = new Queue<string>();
        double paperNeeded = 0;
        double ribbonNeeded = 0;

        const string path = "/home/toohka/Documents/DEV/AdventOfCode/AoC2015/inputs/input_2.in";
        Console.WriteLine(path);


        try
        {
            using (TextReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    dimensions.Enqueue(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Readfile not found!");
        }

        foreach (var gift in dimensions)
        {
            string[] edgesStrings = gift.Split('x');
            List<int> edges = new List<int>();

            foreach (var edge in edgesStrings)
            {
                edges.Add(Int32.Parse(edge));
            }

            edges.Sort();
            int l = edges[0], w = edges[1], h = edges[2];

            //paperNeeded += 2 * (l * w + w * h + h * l) + l * w;
            ribbonNeeded += 2 * (l + w) + l * w * h;
        }

        Console.WriteLine("Paper needed: {0}", paperNeeded);
        Console.WriteLine("Ribbon needed: {0}", ribbonNeeded);
    }
}