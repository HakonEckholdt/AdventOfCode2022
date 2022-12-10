namespace AdventOfCode2022.Tasks.Task9;

public class Knot
{
    public Coordinate Possition { get; set; } = new Coordinate(0, 0);
    public Coordinate StartPossition { get; set; } = new Coordinate(0, 0);
    public Knot TailingKnot { get; set; }
    public Knot LeadingKnot { get; set; }

    public Knot()
    {

    }

    public Knot(Knot knot)
    {
        TailingKnot = knot;
    }


    public void MoveHeadOne(string direction, bool checkTail = true)
    {
        switch (direction)
        {
            case "R":
                MoveRight(checkTail);
                break;
            case "L":
                MoveLeft(checkTail);
                break;
            case "U":
                MoveUp(checkTail);
                break;
            case "D":
                MoveDown(checkTail);
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public void MoveRight(bool checkTail = true)
    {
        Possition.Xpossition++;
        var test = TailTouchingHead();
        if (checkTail && !TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    public void MoveLeft(bool checkTail = true)
    {
        Possition.Xpossition--;
        if (checkTail && !TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    public void MoveUp(bool checkTail = true)
    {
        Possition.Ypossition++;
        if (checkTail && !TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    public void MoveDown(bool checkTail = true)
    {
        Possition.Ypossition--;
        if (checkTail && !TailTouchingHead())
        {
            TailCatchUp();
        }
    }

    private void TailCatchUp()
    {
        if (TailingKnot == null)
            return;
        if (TailInSameCol(out _))
        {
            var moveAction = Possition.Ypossition - TailingKnot.Possition.Ypossition > 0 ? "U" : "D";
            TailingKnot.MoveHeadOne(moveAction);

        } else if (TailInSameRow(out _))
        {
            var moveAction = Possition.Xpossition - TailingKnot.Possition.Xpossition > 0 ? "R" : "L";
            TailingKnot.MoveHeadOne(moveAction);
        } else
        {
            var moveAction = Possition.Ypossition - TailingKnot.Possition.Ypossition > 0 ? "U" : "D";
            TailingKnot.MoveHeadOne(moveAction, false);
            moveAction = Possition.Xpossition - TailingKnot.Possition.Xpossition > 0 ? "R" : "L";
            TailingKnot.MoveHeadOne(moveAction);
        }
    }



    public bool TailTouchingHead()
    {
        return IsHorizontalyClose() && IsVerticallyClose();
    }

    private bool TailInSameRow(out int distance)
    {
        distance = Possition.Ypossition - TailingKnot.Possition.Ypossition;
        return distance == 0;
    }

    private bool TailInSameCol(out int distance)
    {
        distance = Possition.Xpossition - TailingKnot.Possition.Xpossition;
        return distance == 0;
    }

    private bool IsHorizontalyClose()
    {
        if (TailingKnot == null)
            return true;
        return (Possition.Xpossition + 1 >= TailingKnot.Possition.Xpossition) && (Possition.Xpossition - 1 <= TailingKnot.Possition.Xpossition);
    }

    private bool IsVerticallyClose()
    {
        if (TailingKnot == null)
            return true;
        return (Possition.Ypossition + 1 >= TailingKnot.Possition.Ypossition) && (Possition.Ypossition - 1 <= TailingKnot.Possition.Ypossition);
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

