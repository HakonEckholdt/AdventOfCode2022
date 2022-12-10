using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task10
{
    public class Register
    {
        public int XRegisterValue { get; set; } = 1;
        public int Cycle { get; set; }
        public Dictionary<int, int> RegisterValueLog { get; set; } = new Dictionary<int, int>();
        public List<string> Program { get; set; }

        public void LoadProgram(List<string> program)
        {
            Cycle = 0;
            Program = program;
        }

        public void ExecuteProgram()
        {
            var programPointer = 0;
            while(programPointer < Program.Count())
            {
                var action = Program[programPointer].Split(" ");
                switch (action[0])
                {
                    case "noop":
                        Cycle++;
                        break;
                    case "addx":
                        Cycle++;
                        if ((Cycle - 20) % 40 == 0)
                            RecordCycleRegistryValue();
                        Cycle++;
                        if ((Cycle - 20) % 40 == 0)
                            RecordCycleRegistryValue();
                        XRegisterValue += int.Parse(action[1]);
                        break;
                }
                programPointer++;
            }
        }

        private void RecordCycleRegistryValue()
        {
            RegisterValueLog.Add(Cycle, XRegisterValue);
        }

        public void PrintCycleRegisterValueLog()
        {
            var totalSignal = 0;
            foreach (var (key, value) in RegisterValueLog)
            {
                Console.WriteLine($"Cycle: {key}, X-registry: {value}, SignalStrenght = {key*value}");
                totalSignal += key * value;
            }
            Console.WriteLine($"Total SignalStrenght: {totalSignal}");
        }

    }
}
