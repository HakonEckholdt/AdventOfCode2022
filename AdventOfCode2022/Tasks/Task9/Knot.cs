namespace AdventOfCode2022.Tasks.Task9;

public class Knot
{
    public Coordinate HeadPossition { get; set; } = new Coordinate(0, 0);
    public Coordinate TailPossition { get; set; } = new Coordinate(0, 0);
    public Coordinate StartPossition { get; set; } = new Coordinate(0, 0);
    public List<Coordinate> TailVisitedLog { get; set; } = new List<Coordinate>() { new Coordinate(0, 0) };
    public Knot TailingKnot { get; set; }

    public Knot()
    {

    }

    public Knot(Knot knot)
    {
        TailingKnot = knot;
    }

    public void ExecuteInput(List<string> data)
    {
        foreach (var dataline in data)
        {
            var datalineArray = dataline.Split(" ");
            for (var i = 0; i < int.Parse(datalineArray[1]); i++)
            {
                MoveHeadOne(datalineArray[0]);
            }
        }
    }

    public void MoveHeadOne(string direction)
    {
        switch (direction)
        {
            case "R":
                MoveRight();
                break;
            case "L":
                MoveLeft();
                break;
            case "U":
                MoveUp();
                break;
            case "D":
                MoveDown();
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public void MoveRight()
    {
        HeadPossition.Xpossition++;
        var test = TailTouchingHead();
        if (!TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    public void MoveLeft()
    {
        HeadPossition.Xpossition--;
        if (!TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    public void MoveUp()
    {
        HeadPossition.Ypossition++;
        if (!TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    public void MoveDown()
    {
        HeadPossition.Ypossition--;
        if (!TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    private void TailCatchUp()
    {
        if (TailInSameCol(out _))
        {
            TailPossition.Ypossition += Math.Sign(HeadPossition.Ypossition - TailPossition.Ypossition);
        } else if (TailInSameRow(out _))
        {
            TailPossition.Xpossition += Math.Sign(HeadPossition.Xpossition - TailPossition.Xpossition);
        } else
        {
            TailPossition.Xpossition += Math.Sign(HeadPossition.Xpossition - TailPossition.Xpossition);
            TailPossition.Ypossition += Math.Sign(HeadPossition.Ypossition - TailPossition.Ypossition);
        }
        UpdateTailLog();
    }

    public void UpdateTailLog()
    {
        if (TailVisitedLog.Any(coord => TailPossition.IsEqual(coord)))
            return;
        TailVisitedLog.Add(new Coordinate(TailPossition));
    }

    public void PrintTailLog()
    {
        var maxCol = (TailVisitedLog.Max(x => x.Xpossition));
        var maxRow = (TailVisitedLog.Max(y => y.Ypossition));
        for (int r = maxRow; r >= 0; r--)
        {
            for (int c = 0; c <= maxCol; c++)
            {
                if (r == 0 && c == 0)
                    Console.Write("S");
                else
                    Console.Write(TailVisitedLog.Any(x => x.Xpossition == c && x.Ypossition == r) ? "#" : ".");
            }
            Console.Write("\n");
        }

        Console.WriteLine($"Tail visited {TailVisitedLog.Count()} coordinates");
    }

    public bool TailTouchingHead()
    {
        return IsHorizontalyClose() && IsVerticallyClose();
    }

    private bool TailInSameRow(out int distance)
    {
        distance = HeadPossition.Ypossition - TailPossition.Ypossition;
        return distance == 0;
    }

    private bool TailInSameCol(out int distance)
    {
        distance = HeadPossition.Xpossition - TailPossition.Xpossition;
        return distance == 0;
    }

    private bool IsHorizontalyClose()
    {
        return (HeadPossition.Xpossition + 1 >= TailPossition.Xpossition) && (HeadPossition.Xpossition - 1 <= TailPossition.Xpossition);
    }

    private bool IsVerticallyClose()
    {
        return (HeadPossition.Ypossition + 1 >= TailPossition.Ypossition) && (HeadPossition.Ypossition - 1 <= TailPossition.Ypossition);
    }

}

public class Coordinate
{
    public Coordinate(int x, int y)
    {
        Xpossition = x;
        Ypossition = y;
    }

    public Coordinate(Coordinate coordinate)
    {
        Xpossition = coordinate.Xpossition;
        Ypossition = coordinate.Ypossition;
    }

    public int Xpossition { get; set; }
    public int Ypossition { get; set; }

    public bool IsEqual(Coordinate coordinate)
    {
        return (Xpossition == coordinate.Xpossition && Ypossition == coordinate.Ypossition);
    }
}

