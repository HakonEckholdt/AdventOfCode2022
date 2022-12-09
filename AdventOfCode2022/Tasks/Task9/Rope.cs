using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task9
{
    public class Rope
    {
        public List<Knot> knots { get; set; }

        public Rope()
        {
            knots = new List<Knot>() 
            {
                new Knot(),
                new Knot()
            };
        }
    }
}
