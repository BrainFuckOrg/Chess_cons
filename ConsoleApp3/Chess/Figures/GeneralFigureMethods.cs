using ArraySumNameSpace;
using FieldNameSpace;
using FiguresNameSpace;

namespace ConsoleApp3;

public static class GeneralFigureMethods
{
    public static Boolean HasAnotherThisColorFigure(SByte[] from, SByte[] to)
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
    
    public static Boolean HasAnotherFigureInMoveLine(SByte[] from, SByte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        
        SByte[] SumedCheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };

        SByte numOfIterations = Math.Max(Math.Abs(SumedCheckCoors[0]), Math.Abs(SumedCheckCoors[1]));
        if (SumedCheckCoors[0] != 0 && SumedCheckCoors[1] != 0)
        {
            SumedCheckCoors[1] = (SByte)(SumedCheckCoors[1] < 0 ? 1 : -1);
            SumedCheckCoors[0] = (SByte)(SumedCheckCoors[0] < 0 ? 1 : -1);
        }
        else
        {
            if (SumedCheckCoors[0] == 0) SumedCheckCoors[1] = (SByte)(SumedCheckCoors[1] < 0 ? 1 : -1);
            else SumedCheckCoors[0] = (SByte)(SumedCheckCoors[0] < 0 ? 1 : -1);
        }

        SByte[] newArr = (SByte[])from.Clone();
        for (SByte i = 1; i < numOfIterations; i++)
        {
            newArr = ArraySum.sum(newArr, SumedCheckCoors); 
            if (Table[newArr[0], newArr[1]] != FigureNames.Empty) return true;
        }

        return false;
    }

    public static void MoveFigureFromTo(SByte[] from, SByte[] to)
    {
        FigureNames[,] table = Field.SingleField.Table;
        table[to[0], to[1]] = table[from[0], from[1]];
        table[from[0], from[1]] = FigureNames.Empty;
    }

    public static Boolean IsKingChecked(Side side)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        FigureNames searchedFigure;
        switch (side)
        {
            case Side.White:
                searchedFigure = FigureNames.KingW;
                break;
            case Side.Black:
                searchedFigure = FigureNames.KingB;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(side), side, null);
        }

        for (SByte col = 0; col < 8; col++)
        for (SByte row = 0; row < 8; row++)
        {
            if (Table[col, row] == searchedFigure)
            {
                return CanHit.CanHitCell(new[] { col, row }, side == Side.Black ? Side.White : Side.Black);
            }
        }

        throw new Exception("You haven't King on the board");

    }

    public static Boolean IsKingChecked(SByte[] from)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0],from[1]]))
        {
            return IsKingChecked(Side.Black);
        }

        return IsKingChecked(Side.White);
    }
}