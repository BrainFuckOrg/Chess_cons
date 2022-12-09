using ConsoleApp3;
using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;

public static class Bishop
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        Field.CreateCheckPoint();
        if (!BishopCanMove(from, to)) return false;
        GeneralFigureMethods.MoveFigureFromTo(from,to);
        if (GeneralFigureMethods.IsKingChecked(to))
        {
            Field.Rollback();
            return false;
        }

        return true;
    }

    public static Boolean BishopCanMove(SByte[] from, SByte[] to)
    {
        if (!isThisFigureMove(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherThisColorFigure(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(from, to)) return false;
        return true;
    }
    private static Boolean isThisFigureMove(SByte[] from, SByte[] to)
    {
        SByte[] CheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };
        return Math.Abs(CheckCoors[0]) == Math.Abs(CheckCoors[1]);
    }

    
}