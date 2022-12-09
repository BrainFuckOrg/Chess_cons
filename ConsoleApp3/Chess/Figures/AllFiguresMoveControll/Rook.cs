using ConsoleApp3;
using FieldNameSpace;

namespace Figure;

public static class Rook
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        Field.CreateCheckPoint();
        if (!RookCanMove(from, to)) return false;
        GeneralFigureMethods.MoveFigureFromTo(from,to);
        Castling.RookMove(from);
        if (GeneralFigureMethods.IsKingChecked(to))
        {
            Field.Rollback();
            return false;
        }
        return true;
    }

    public static Boolean RookCanMove(SByte[] from, SByte[] to)
    {
        if (!isThisFigureMove(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherThisColorFigure(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(from, to)) return false;
        return true;
    }
    private static Boolean isThisFigureMove(SByte[] from, SByte[] to)
    {
        SByte[] CheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };
        return (Math.Abs(CheckCoors[0]) == 0 && Math.Abs(CheckCoors[1]) != 0) ||
               (Math.Abs(CheckCoors[0]) != 0 && Math.Abs(CheckCoors[1]) == 0);
    }
    
}