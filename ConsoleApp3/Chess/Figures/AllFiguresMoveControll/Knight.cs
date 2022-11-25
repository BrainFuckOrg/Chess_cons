using ConsoleApp3;
using FiguresNameSpace;

namespace Figure;

using FieldNameSpace;

public static class Knight
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        if (!isThisFigureMove(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherThisColorFigure(from, to)) return false;
        GeneralFigureMethods.MoveFigureFromTo(from,to);

        return true;
    }

    private static Boolean isThisFigureMove(SByte[] from, SByte[] to)
    {
        SByte[] CheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };
        return (Math.Abs(CheckCoors[0]) == 2 && Math.Abs(CheckCoors[1]) == 1) ||
               (Math.Abs(CheckCoors[0]) == 1 && Math.Abs(CheckCoors[1]) == 2);
    }

    private static Boolean HasAnotherThisColorFigure(SByte[] from, SByte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        if (Table[from[0], from[1]] == FigureNames.Empty)
            return true;

        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0], from[1]]))
        {
            return FiguresNameSpace.Figure.BlackFigures.Contains(Table[to[0], to[1]]);
        }

        return FiguresNameSpace.Figure.WhiteFigures.Contains(Table[to[0], to[1]]);
    }
}