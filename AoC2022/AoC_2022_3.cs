using System.Diagnostics;

namespace AoC2022;

public class AoC_2022_3
{
    private static List<string> _lines = Reader.Read("input_3");
    private static List<Rucksack> _rucksacks = new List<Rucksack>();
    private static List<char> _itemsToSort = new List<char>();
    private static List<char> _alphabet = alphabet();

    public static double Riddle3()
    {
        RucksackFactory();
        Sort();

        
        return CountPriority();
    }

    private static double CountPriority()
    {
        double priority = 0;
        foreach (var item in _itemsToSort)
        {
            var prior = _alphabet.IndexOf(_alphabet.Find(x => x.Equals(item)));
            Console.WriteLine(item+" | "+prior);
            priority += prior;
        }

        return priority;
    }
    private static void Sort()
    {
        foreach (var rucksack in _rucksacks)
        {
            foreach (var thingA in rucksack.pocketA)
            {
                foreach (var thingB in rucksack.pocketB)
                {
                    if(thingA == thingB)
                        _itemsToSort.Add(thingA);
                }
            }
        }
    }
    private static void RucksackFactory()
    {
        foreach (var line in _lines)
        {
            var things = line.ToCharArray();
            var left = things.Take(things.Length / 2).ToArray();
            var right = things.Skip(things.Length/2).Take(things.Length / 2).ToArray();
            _rucksacks.Add(new Rucksack(left, right));
        }
    }

    private static List<char> alphabet()
    {
        var list = new List<char>();
        list.Add('_');
        for (var let = 'a'; let <= 'z'; let++)
        {
            list.Add(let);
        }
        for (var let = 'A'; let <= 'Z'; let++)
        {
            list.Add(let);
        }

        foreach (var li in list)
        {
            Console.Write(li+" ");
        }

        return list;
    }
    private class Rucksack
    {
        public char[] pocketA;
        public char[] pocketB;

        public Rucksack(char[] pocketA, char[] pocketB)
        {
            this.pocketA = pocketA;
            this.pocketB = pocketB;
        }
    }
    
}