namespace AdventOfCode2022.Tasks.Task9
{
    public class Rope
    {
        public List<Knot> Knots { get; set; }
        public List<Coordinate> TailPositionLog { get; set; } = new List<Coordinate>() { new Coordinate(0, 0) };

        public Rope(int numberOfKnots)
        {
            var tempKnots = new List<Knot>();
            for (var i = 0; i < numberOfKnots; i++)
            {
                if (i == 0)
                    tempKnots.Add(new Knot());
                else
                    tempKnots.Add(new Knot(tempKnots[i-1]));
            }
            tempKnots.Reverse();
            Knots = tempKnots;
        }

        public void ExecuteInput(List<string> data)
        {
            foreach (var dataline in data)
            {
                PrintCurrentPossition();
                var datalineArray = dataline.Split(" ");
                //Console.ReadLine();
                for (var i = 0; i < int.Parse(datalineArray[1]); i++)
                {
                    Knots[0].MoveHeadOne(datalineArray[0]);
                    UpdateTailPositionLog();
                }
            }
        }

        public void UpdateTailPositionLog()
        {
            if (TailPositionLog.Any(x => (x.Xpossition == Knots.Last().Possition.Xpossition) && (x.Ypossition == Knots.Last().Possition.Ypossition)))
                return;
            TailPositionLog.Add(new Coordinate(Knots.Last().Possition));
        }

        public void PrintTailLog()
        {
            var maxCol = (TailPositionLog.Max(x => x.Xpossition));
            var maxRow = (TailPositionLog.Max(y => y.Ypossition));
            var minCol = (TailPositionLog.Min(x => x.Xpossition));
            var minRow = (TailPositionLog.Min(y => y.Ypossition));
            for (int r = maxRow; r >= minRow; r--)
            {
                for (int c = minCol; c <= maxCol; c++)
                {
                    if (r == 0 && c == 0)
                        Console.Write("S");
                    else
                        Console.Write(TailPositionLog.Any(x => x.Xpossition == c && x.Ypossition == r) ? "#" : ".");
                }
                Console.Write("\n");
            }

            Console.WriteLine($"Tail visited {TailPositionLog.Count()} coordinates");
        }

        public void PrintCurrentPossition()
        {
            var maxCol = (Knots.Max(x => x.Possition.Xpossition));
            var maxRow = (Knots.Max(y => y.Possition.Ypossition));
            var minCol = (Knots.Min(x => x.Possition.Xpossition));
            var minRow = (Knots.Min(y => y.Possition.Ypossition));
            for (int r = maxRow; r >= minRow; r--)
            {
                for (int c = minCol; c <= maxCol; c++)
                {
                    if (r == 0 && c == 0)
                        Console.Write("S");
                    else
                        Console.Write(Knots.Any(x => x.Possition.Xpossition == c && x.Possition.Ypossition == r) ? "X" : ".");
                }
                Console.Write("\n");
            }
        }

    }
}
