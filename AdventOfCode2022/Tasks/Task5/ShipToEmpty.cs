using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task5
{
    public class ShipToEmpty
    {
        public List<CrateStack> CrateStacks { get; set; }

        public ShipToEmpty(List<CrateStack> stacks)
        {
            CrateStacks = stacks;
        }

        public void MakeMoves(List<Move> moves)
        {
            foreach(var move in moves)
            {
                MakeMove(move);
            }
        }

        public void MakeMove2(Move move)
        {
            var cratesTaken = CrateStacks[move.FromStack].TakeCrates(move.NumberOfCrates);
            CrateStacks[move.ToStack].PlaceCratesSameOrder(cratesTaken);
        }

        public void MakeMoves2(List<Move> moves)
        {
            foreach (var move in moves)
            {
                MakeMove2(move);
            }
        }

        public void MakeMove(Move move)
        {
            var cratesTaken = CrateStacks[move.FromStack].TakeCrates(move.NumberOfCrates);
            CrateStacks[move.ToStack].PlaceCrates(cratesTaken);
        }

        public void PrintMessage()
        {
            Console.WriteLine(string.Join(string.Empty, CrateStacks.Select(stack => stack.Crates.Last().Trim('[', ']'))));
        }

        public void PrintShip()
        {
            var highestStack = CrateStacks.Max(x => x.Crates.Count());
            for (var i = 0; i < highestStack; i++)
            {
                var printLine = "";
                foreach (var stack in CrateStacks)
                {
                    if (stack.Crates.Count() >= highestStack - i)
                        printLine += stack.Crates[highestStack - 1 - i] + " ";
                    else
                        printLine += "    ";
                }
                Console.WriteLine(printLine);
            }
            
        }
    }

    public class Move
    {
        public int NumberOfCrates { get; set; }
        public int FromStack { get; set; }
        public int ToStack { get; set; }

        public Move(string move)
        {
            var moveList = move.Split(" ");
            NumberOfCrates = int.Parse(moveList[1]);
            FromStack = int.Parse(moveList[3]) - 1;
            ToStack = int.Parse(moveList[5]) - 1;
        }
    }

}
