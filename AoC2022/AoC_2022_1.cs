using System.Text.Json.Serialization.Metadata;

namespace AoC2022;
public class AoC_2022_1
{
    private static List<Elf> _elves = new List<Elf>();
    private static List<string> _lines = Reader.Read("input_1");
    private static uint _linesCheck = 0;
    private static uint _linesCheckParse = 0;
    
    public static double Riddle1()
    {
        DispenseCalories();

        //Console.WriteLine(_linesCheck==_linesCheckParse);
/*
        foreach (var line in _lines)
        {
            Console.WriteLine("line: " + line);
        }
        foreach (var elf in _elves)
        {
            Console.WriteLine("elf"+elf.Calories);
        }*/

        var (max1, index1) = GetFattestElf(0);
        _elves.RemoveAt(index1);
        var (max2, index2) = GetFattestElf(max1);
        _elves.RemoveAt(index2);
        var (max3, index3) = GetFattestElf(max2);

        return max1 + max2 + max3;

    }

    private static (double max, int index) GetFattestElf(double exclude)
    {
        double max = 0;
        var index = 0;
        for (var i = 0; i < _elves.Count; i++)
        {
            if (_elves[i].Calories > max)
            {
                max = _elves[i].Calories;
                index = i;
            }
        }
        return (max, index);
    }
    private static void DispenseCalories()
    {
        double calories = 0;
        foreach (var line in _lines)
        {
            if (line == "")
            {
                _linesCheck++;
            }
            var parsable = double.TryParse(line, out var cal);

            if (parsable)
                calories += cal;
            else
            {
                _linesCheckParse++;
                _elves.Add(new Elf(calories));
                calories = 0;
            }
        }
    }

    private class Elf
    {
        public double Calories;

        public Elf(double calories)
        {
            this.Calories = calories;
        }

        public void Feed(uint calories)
        {
            this.Calories += calories;
        }
    }
}