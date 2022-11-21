using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;

public static class Pawn
{
    //TODO pawn -> Queen
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        Table[from[0], from[1]] = FigureNames.Empty;
        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0], from[1]]))
        {
            Table[to[0], to[1]] = FigureNames.PawnB;
        }
        else
        {
            Table[to[0], to[1]] = FigureNames.PawnW;
        }
        return true;
    }
}