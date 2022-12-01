using ConsoleApp3;

namespace Figure;

public static class Queen
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        if (!QueenCanMove(from, to)) return false;
        GeneralFigureMethods.MoveFigureFromTo(from,to);
        if (!GeneralFigureMethods.checkKingCheckedAndRemoveLastMoveIfChecked(from, to)) return false;
        return true;
    }

    public static Boolean QueenCanMove(SByte[] from, SByte[] to)
    {
        if (!isThisFigureMove(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherThisColorFigure(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(from, to)) return false;
        return true;
    }
    private static Boolean isThisFigureMove(sbyte[] from, sbyte[] to)
    {
        SByte[] CheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };
        return Math.Abs(CheckCoors[0]) == Math.Abs(CheckCoors[1]) || (Math.Abs(CheckCoors[0]) == 0 && Math.Abs(CheckCoors[1]) != 0) ||
               (Math.Abs(CheckCoors[0]) != 0 && Math.Abs(CheckCoors[1]) == 0);
    }
}