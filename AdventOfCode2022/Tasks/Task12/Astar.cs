using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks.Task12
{
    public class Astar
    {
        List<Position> ActivePositions = new List<Position>();
        List<Position> MappedPossitions = new List<Position>();
        Position StartPos;
        List<List<int>> HeightMap;
        int Xend;
        int Yend;

        public Astar(int xstart, int ystart, int xend, int yend, List<List<int>> heightMap)
        {
            Xend = xend;
            Yend = yend;
            HeightMap = heightMap;
            StartPos = new Position(xstart, ystart, null, -1);
        }

        public int Solve()
        {
            StartPos.SetHeuristic(Xend, Yend);
            ActivePositions.Add(StartPos);
            while(ActivePositions.Any())
            {
                var active = ActivePositions.OrderBy(x => x.HeuristicCost).First();
                if (active.Xpos == Xend && active.Ypos == Yend)
                {
                    //Console.WriteLine("End Reached");
                    //Console.WriteLine($"Steps Used = {active.Cost}");
                    return active.Cost;
                }
                MappedPossitions.Add(active);
                ActivePositions.Remove(active);
                var positions = GetPossiblePositions(active);
                foreach (var position in positions)
                {
                    if (MappedPossitions.Any(pos  => pos.Xpos == position.Xpos && pos.Ypos == position.Ypos))
                        continue;

                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (ActivePositions.Any(pos => pos.Xpos == position.Xpos && pos.Ypos == position.Ypos))
                    {
                        var existingTile = ActivePositions.First(pos => pos.Xpos == position.Xpos && pos.Ypos == position.Ypos);
                        if (existingTile.HeuristicCost > active.HeuristicCost)
                        {
                            ActivePositions.Remove(existingTile);
                            ActivePositions.Add(position);
                        }
                    }
                    else
                    {
                        //We've never seen this tile before so add it to the list. 
                        ActivePositions.Add(position);
                    }
                }
            }
            //PrintVisited();
            return int.MaxValue;
        }

        public void PrintVisited()
        {
            for(var row = 0; row < HeightMap.Count(); row ++)
            {
                for(var col = 50; col < HeightMap[0].Count(); col++)
                {
                    var digitAdjuster = HeightMap[row][col] > 9 ? "" : " ";
                    Console.Write(MappedPossitions.Any(pos => pos.Xpos == row && pos.Ypos == col) ? $"[{HeightMap[row][col]}{digitAdjuster}]" : $" {HeightMap[row][col]}{digitAdjuster} ");
                }
                Console.Write("<>|<>\n");
            }
        }

        public List<Position> GetPossiblePositions(Position activePos)
        {
            var posiblePos = new List<Position>() {
                new Position(activePos.Xpos - 1, activePos.Ypos, activePos, activePos.Cost),
                new Position(activePos.Xpos + 1, activePos.Ypos, activePos, activePos.Cost),
                new Position(activePos.Xpos, activePos.Ypos - 1, activePos, activePos.Cost),
                new Position(activePos.Xpos, activePos.Ypos + 1, activePos, activePos.Cost)
            };
            posiblePos.ForEach(pos => pos.SetHeuristic(Xend, Yend));
            var realPossible = posiblePos
                .Where(pos => pos.Xpos >= 0 && pos.Xpos < HeightMap.Count())
                .Where(pos => pos.Ypos >= 0 && pos.Ypos < HeightMap.First().Count())
                .ToList();
            realPossible.ForEach(pos => pos.SetHeight(HeightMap));
            //return realPossible.Where(pos => pos.Height == activePos.Height || pos.Height + 1 == activePos.Height || pos.Height - 1 == activePos.Height).ToList();
            return realPossible.Where(pos => pos.Height - 1 <= activePos.Height).ToList();
        }
    }
}