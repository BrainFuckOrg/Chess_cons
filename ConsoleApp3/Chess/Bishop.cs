using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;

public static class Bishop
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0], from[1]]))
        {
            Table[to[0], to[1]] = FigureNames.BishopB;
        }
        else
        {
            Table[to[0], to[1]] = FigureNames.BishopW;
        }
        Table[from[0], from[1]] = FigureNames.Empty;

        return true;
    }
}