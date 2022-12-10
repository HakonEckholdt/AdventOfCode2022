using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task10
{
    public class Sprite
    {
        public int Position { get; set; } = 1;

        public bool CoversPosition(int cyclePosition)
        {
            if (cyclePosition >= Position - 1 && Position + 1 >= cyclePosition)
                return true;
            return false;
        }
    }
}
