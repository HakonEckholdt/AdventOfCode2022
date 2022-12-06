using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Models
{
    public record Coordinate (int Xcoord, int Ycoord)
    {    }

    public class Line
    {
        public Line(Coordinate start, Coordinate end)
        {
            Start = start;
            End = end;
        }
        public Coordinate Start { get; set; } 
        public Coordinate End { get; set; }

        private bool IsHorizontal()
        {
            if (Start.Xcoord == End.Xcoord)
                return false;
            return true;
        }

        public List<Coordinate> GetCoordsOfLine()
        {
            var result = new List<Coordinate>();

            if (IsHorizontal())
            {
                if (Start.Xcoord < End.Xcoord)
                {
                    for (int x = Start.Xcoord; x <= End.Xcoord; x++)
                    {
                        result.Add(new Coordinate(x, Start.Ycoord));
                    }
                } else
                {
                    for (int x = Start.Xcoord; x >= End.Xcoord; x--)
                    {
                        result.Add(new Coordinate(x, Start.Ycoord));
                    }
                }

            } else
            {
                if (Start.Ycoord < End.Ycoord)
                {
                    for (int y = Start.Ycoord; y <= End.Ycoord; y++)
                    {
                        result.Add(new Coordinate(Start.Xcoord, y));
                    }
                }
                else
                {
                    for (int y = Start.Ycoord; y >= End.Ycoord; y--)
                    {
                        result.Add(new Coordinate(Start.Xcoord, y));
                    }
                }

            }
            return result;
        }
    }
}
