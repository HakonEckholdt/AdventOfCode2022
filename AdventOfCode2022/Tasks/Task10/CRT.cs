using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task10
{
    public class CRT
    {
        public Sprite Sprite { get; set; } = new Sprite();
        public Register Register { get; set; } = new Register();
        public int Cycle { get; set; } = 1;
        public List<List<string>> Screen = new List<List<string>>();
        public Dictionary<int, int> RegisterValueLog { get; set; } = new Dictionary<int, int>();

        public void ExecuteCRTProgram(List<string> programList)
        {
            Register.LoadProgram(programList);
            while(Register.ExecuteCycle())
            {
                Sprite.Position = Register.XRegisterValue;
                if (((Cycle - 1) % 40) == 0)
                {
                    Screen.Add(new List<string>());
                }
                RecordCycleRegistryValue();
                Screen.Last().Add(Sprite.CoversPosition((Cycle - 1)% 40) ? "#": ".");
                Cycle++;
            }
            PrintCycleRegisterValueLog();
        }

        public void PrintScreen()
        {
            foreach(var row in Screen)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private void RecordCycleRegistryValue()
        {
            if ((Cycle - 20) % 40 == 0)
                RegisterValueLog.Add(Cycle, Register.XRegisterValue);
        }

        public void PrintCycleRegisterValueLog()
        {
            var totalSignal = 0;
            foreach (var (key, value) in RegisterValueLog)
            {
                Console.WriteLine($"Cycle: {key}, X-registry: {value}, SignalStrenght = {key * value}");
                totalSignal += key * value;
            }
            Console.WriteLine($"Total SignalStrenght: {totalSignal}");
        }
    }
}
