using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task1
{
    public class Elf
    {
        public int Id { get; }
        public List<int> Inventory { get; set; } = new List<int>();
        public int TotalCalories { get; set; }

        public Elf(int id)
        {
            Id = id;
        }

        public void CalculateTotalCalories()
        {
            TotalCalories = Inventory.Sum(x => x);
        }
    }
}
