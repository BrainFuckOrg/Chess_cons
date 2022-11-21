using ArraySumNameSpace;
using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;

public static class Rock
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        if (!isThisFigureMove(from, to)) return false;
        if (HasAnotherThisColorFigure(from, to)) return false;
        if (HasAnotherFigureInMoveLine(from, to)) return false;
        FigureNames[,] Table = Field.SingleField.Table;
        Table[from[0], from[1]] = FigureNames.Empty;
        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0], from[1]]))
        {
            Table[to[0], to[1]] = FigureNames.RockB;
        }
        else
        {
            Table[to[0], to[1]] = FigureNames.RockW;
        }
        return true;
    }

    private static Boolean isThisFigureMove(SByte[] from, SByte[] to)
    {
        SByte[] CheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };
        return (Math.Abs(CheckCoors[0]) == 0 && Math.Abs(CheckCoors[1]) != 0) ||
               (Math.Abs(CheckCoors[0]) != 0 && Math.Abs(CheckCoors[1]) == 0);
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
    private static Boolean HasAnotherFigureInMoveLine(SByte[] from, SByte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        
        SByte[] SumedCheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };
        SByte numOfIterations = Math.Max(Math.Abs(SumedCheckCoors[0]), Math.Abs(SumedCheckCoors[1]));
        if (SumedCheckCoors[0] == 0) SumedCheckCoors[1] = (SByte)(SumedCheckCoors[1] > 0 ? 1 : -1);
        else SumedCheckCoors[0] = (SByte)(SumedCheckCoors[0] > 0 ? 1 : -1);
        SByte[] newArr = (SByte[])from.Clone();
        for (SByte i = 1; i < numOfIterations; i++)
        {
            newArr = ArraySum.sum(newArr, SumedCheckCoors);
            if (Table[newArr[0], newArr[1]] != FigureNames.Empty) return true;
        }

        return false;



    }
}