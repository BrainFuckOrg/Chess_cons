using ConsoleApp3;
using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;

public static class Queen
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        GeneralFigureMethods.MoveFigureFromTo(from,to);

        return true;
    }
}