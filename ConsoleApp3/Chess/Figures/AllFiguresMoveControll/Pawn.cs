using ConsoleApp3;

namespace Figure;

public static class Pawn
{
    //TODO pawn -> Queen
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        if (!isThisFigureMove(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherThisColorFigure(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(from, to)) return false;
        GeneralFigureMethods.MoveFigureFromTo(from,to);
        return true;
    }

    private static Boolean isThisFigureMove(sbyte[] from, sbyte[] to)
    {
        return true;
        
    }
}