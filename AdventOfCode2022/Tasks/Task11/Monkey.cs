using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task11
{
    public class Monkey
    {
        public List<int> ItemsWorryLevel;
        public Func<int, int> MonkeyOperation;
        public int MonkeyTestNumber;
        public int MonkeyThrowTrue;
        public int MonkeyThrowFalse;
        public int ItemsInspected = 0;

        public Monkey(List<string> monkeyConstructor)
        {
            ItemsWorryLevel = monkeyConstructor[1].Trim().Substring(15).Split(",").Select(x => int.Parse(x)).ToList();
            MonkeyOperation = CreateFunction(monkeyConstructor[2].Trim().Substring(17));
            MonkeyTestNumber = int.Parse(monkeyConstructor[3].Trim().Substring(19));
            MonkeyThrowTrue = int.Parse(monkeyConstructor[4].Trim().Substring(25));
            MonkeyThrowFalse = int.Parse(monkeyConstructor[5].Trim().Substring(26));
        }

        public List<(int monkey, int worryLevel)> ExecuteMonkeyBussiness()
        {
            var passedOnItems = new List<(int monkey, int worryLevel)>();
            foreach(var worryLevel in ItemsWorryLevel)
            {
                var newWorryLevel = MonkeyOperation(worryLevel);
                newWorryLevel /= 3;
                if (newWorryLevel % MonkeyTestNumber == 0)
                    passedOnItems.Add((MonkeyThrowTrue, newWorryLevel));
                else
                    passedOnItems.Add((MonkeyThrowFalse, newWorryLevel));
                ItemsInspected++;
            }
            ItemsWorryLevel.Clear();
            return passedOnItems;
        }

        private Func<int,int> CreateFunction(string instructions)
        {
            if (instructions.EndsWith("old"))
            {
                if (instructions.Contains("+"))
                {
                    return (x) => x + x;
                }
                else if (instructions.Contains("*"))
                {
                    return (x) => x * x;
                }
                else if (instructions.Contains("-"))
                {
                    return (x) => x - x;
                }
                else if (instructions.Contains("/"))
                {
                    return (x) => x / x;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                if (instructions.Contains("+"))
                {
                    return (x) => x + int.Parse(instructions.Split("+ ")[1]);
                }
                else if (instructions.Contains("*"))
                {
                    return (x) => x * int.Parse(instructions.Split("* ")[1]);
                }
                else if (instructions.Contains("-"))
                {
                    return (x) => x - int.Parse(instructions.Split("- ")[1]);
                }
                else if (instructions.Contains("/"))
                {
                    return (x) => x / int.Parse(instructions.Split("/ ")[1]);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
