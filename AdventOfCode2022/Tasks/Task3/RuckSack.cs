using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task3
{
    public class RuckSack
    {
        public string CompleteInventory { get; set; }
        public string CompartmentOne { get; set; }
        public string CompartmentTwo { get; set; }

        public RuckSack() { }

        public RuckSack(string input) 
        {
            CompartmentOne = input[..(input.Length / 2)];
            CompartmentTwo = input[(input.Length / 2)..];
            CompleteInventory = input;
        }

        public int GetCommonItemValue()
        {
            var common = CompartmentOne.Intersect(CompartmentTwo);
            return common.Sum(item => Dicts.RuckSackItemValues[item]);
        }
    }
}
