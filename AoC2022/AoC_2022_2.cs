namespace AoC2022;

public class AoC_2022_2
{
    private static List<Instruction> _instructions = new List<Instruction>();
    private static List<double> _results = new List<double>();
    private static List<string> _lines = Reader.Read("input_2");

    public static double Riddle2()
    {
        foreach (var line in _lines)
        {
            MakeInstructions(line);
        }

        EvaluateInstructions();
        return Score();
    }

    private static void EvaluateInstructions()
    {
        foreach (var inst in _instructions)
        {
            if (inst.Elf.Equals(inst.Me))
                _results.Add(3 + inst.Me); //Draw
            else if ((inst.Elf == 1 && inst.Me == 3) || (inst.Elf == 2 && inst.Me == 1) || (inst.Elf == 3 && inst.Me == 2))
                _results.Add(inst.Me); //Lose
            else
                _results.Add(6 + inst.Me); //Win
        }
    }

    private static double Score()
    {
        double score = 0;
        foreach (var res in _results)
        {
            Console.WriteLine("Result: {0} | score: {1}", res, score);
            score += res;
        }

        return score;
    }


    private static void MakeInstructions(string line)
    {
        var inst = line.ToCharArray();
        var proc = new double[2];
        proc[0] = inst[0] switch
        {
            'A' => 1,
            'B' => 2,
            'C' => 3,
            _ => proc[0]
        };

        proc[1] = inst[2] switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => proc[1]
        };
        Console.WriteLine("Elf: {0} | Me: {1}", proc[0], proc[1]);
        _instructions.Add(new Instruction(proc[0], proc[1]));
    }

    private class Instruction
    {
        public double Elf;
        public double Me;

        public Instruction(double elf, double me)
        {
            this.Elf = elf;
            this.Me = me;
        }
    }
}