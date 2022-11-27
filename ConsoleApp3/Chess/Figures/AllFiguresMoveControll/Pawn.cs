using ConsoleApp3;
using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;

public static class Pawn
{
    //TODO pawn -> Queen
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        if (!(isThisFigureMove(from, to) || isPawnTake(from, to))) return false;
        if (GeneralFigureMethods.HasAnotherThisColorFigure(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(from, to)) return false;
        GeneralFigureMethods.MoveFigureFromTo(from,to);
        return true;
    }

    private static Boolean isThisFigureMove(sbyte[] from, sbyte[] to)
    {
        if (from[1] != to[1]) return false;
        FigureNames[,] Table = Field.SingleField.Table;
        return Table[from[0], from[1]] switch
        {
            FigureNames.PawnB => from[0] - to[0] == 1 || (from[0] == 6 && from[0] - to[0] == 2),
            FigureNames.PawnW => from[0] - to[0] == -1 || (from[0] == 1 && from[0] - to[0] == -2),
            _ => false
        };
    }
    
    private static Boolean isPawnTake(sbyte[] from, sbyte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        if (Table[to[0], to[1]] == FigureNames.Empty) return false;
        return Table[from[0], from[1]] switch
        {
            FigureNames.PawnB => from[0] - to[0] == 1 && Math.Abs(from[1]-to[1])==1,
            FigureNames.PawnW => from[0] - to[0] == -1 && Math.Abs(from[1]-to[1])==1,
            _ => false
        };
    }
}