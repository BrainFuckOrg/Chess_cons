using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;

public static class Queen
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0], from[1]]))
        {
            Table[to[0], to[1]] = FigureNames.QueenB;
        }
        else
        {
            Table[to[0], to[1]] = FigureNames.QueenW;
        }
        Table[from[0], from[1]] = FigureNames.Empty;

        return true;
    }
}