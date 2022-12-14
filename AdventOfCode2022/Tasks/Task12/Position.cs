using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task12
{
    public class Position
    {
        public int Xpos;
        public int Ypos;
        public int Height;
        public int Cost;
        public int Heuristic;
        public int HeuristicCost;
        public Position Parent;

        public Position() 
        {
            Xpos = 0;
            Ypos = 0;
            Cost = 0;
            Height = 0;
            Parent = null;
        }

        public Position(int xpos, int ypos, Position? parent, int cost)
        {
            Xpos = xpos;
            Ypos = ypos;
            Cost = cost + 1;
            Parent = parent;
        }

        public void SetHeuristic(int targetX, int targetY)
        {
            Heuristic = CalculateManhattanDistance(targetX, Xpos, targetY, Ypos, Height);
            HeuristicCost = Heuristic + Cost;
        }

        public void SetHeight(List<List<int>> heightMap)
        {
            Height = heightMap[Xpos][Ypos];
        }

        private int CalculateManhattanDistance(int x1, int x2, int y1, int y2, int currentHeight)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2) + (25 - currentHeight);
        }
    }
}
