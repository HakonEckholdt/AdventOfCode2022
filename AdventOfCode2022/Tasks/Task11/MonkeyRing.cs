using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task11
{
    public class MonkeyRing
    {
        public List<Monkey> Monkeys = new List<Monkey>();

        public MonkeyRing(List<string> data)
        {
            var currentMonkeyData = new List<string>();
            for (var i = 0; i < data.Count; i++)
            {
                if (i != 0 && i % 7 == 0)
                {
                    Monkeys.Add(new Monkey(currentMonkeyData));
                    currentMonkeyData = new List<string>();
                }
                currentMonkeyData.Add(data[i]);
            }
            Monkeys.Add(new Monkey(currentMonkeyData));
        }

        public void ExecuteMonkeyRing(int numberOfRounds)
        {
            for (var i = 0; i < numberOfRounds; i++)
            {
                Console.WriteLine($"Round {i + 1} done");
                foreach (var monkey in Monkeys)
                {
                    var monkeyPassings = monkey.ExecuteMonkeyBussiness();
                    PassItems(monkeyPassings);
                }
            }
        }

        private void PassItems(List<(int monkey, int worrylevel)> monkeypassings)
        {
            foreach (var passing in monkeypassings)
            {
                Monkeys[passing.monkey].ItemsWorryLevel.Add(passing.worrylevel);
            }
        }

        public void PrintAllPassings()
        {
            foreach(var monkey in Monkeys)
            {
                Console.WriteLine(monkey.ItemsInspected);
            }
        }

        public void PrintLevelOfMonkeyBussiness()
        {
            Console.WriteLine($"Monkeybussiness = {Monkeys.Select(x => x.ItemsInspected).OrderByDescending(i => i).Take(2).Aggregate((total, next) => next * total)}");
        }

    }
}
