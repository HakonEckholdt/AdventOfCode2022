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
        public int CurrentCycleCount { get; set; }
        public List<string> Program { get; set; }
        private int ProgramPointer = 0;
        private Func<int, int>? NextAction = null;

        public void LoadProgram(List<string> program)
        {
            CurrentCycleCount = 0;
            Program = program;
        }

        public bool ExecuteCycle()
        {
            if(NextAction != null)
            {
                XRegisterValue = NextAction(XRegisterValue);
                NextAction = null;
            }
            var action = Program[ProgramPointer].Split(" ");
            switch (action[0])
            {
                case "noop":
                    ProgramPointer++;
                    break;
                case "addx":
                    CurrentCycleCount++;
                    if (CurrentCycleCount == 2)
                    {
                        NextAction = (x) => x + int.Parse(action[1]);
                        CurrentCycleCount = 0;
                        ProgramPointer++;
                    }
                    break;
            }
            if (ProgramPointer > (Program.Count - 1))
                return false;
            return true;

        }

    }
}
