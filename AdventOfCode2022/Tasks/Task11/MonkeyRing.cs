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
            var lcm = Monkeys.Select(x => x.MonkeyTestNumber).Aggregate((S, val) => S * val / gcd(S, val));
            for (var i = 0; i < numberOfRounds; i++)
            {
                Console.WriteLine($"Round {i + 1} done");
                foreach (var monkey in Monkeys)
                {
                    var monkeyPassings = monkey.ExecuteMonkeyBussiness(lcm);
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

        static int gcd(int n1, int n2)
        {
            if (n2 == 0)
            {
                return n1;
            }
            else
            {
                return gcd(n2, n1 % n2);
            }
        }

        public void PrintLevelOfMonkeyBussiness()
        {
            Console.WriteLine($"Monkeybussiness = {Monkeys.Select(x => x.ItemsInspected).OrderByDescending(i => i).Take(2).Aggregate((total, next) => next * total)}");
        }

    }
}
