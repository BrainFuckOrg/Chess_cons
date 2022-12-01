using Figure;

namespace FiguresNameSpace;

public enum FigureNames
{
    Empty,
    PawnW,
    BishopW,
    KnightW,
    RookW,
    KingW,
    QueenW,
    PawnB,
    BishopB,
    KnightB,
    RookB,
    KingB,
    QueenB
}

public enum CastleType
{
    Short,
    Long
}

public enum Side
{
    White,
    Black
}

public static class Figure
{
    public static readonly FigureNames[] WhiteFigures = { FigureNames.BishopW, FigureNames.KingW, FigureNames.KnightW, FigureNames.PawnW, FigureNames.QueenW, FigureNames.RookW };
    public static readonly FigureNames[] BlackFigures = { FigureNames.BishopB, FigureNames.KingB, FigureNames.KnightB, FigureNames.PawnB, FigureNames.QueenB, FigureNames.RookB };
}

public static class CanHit
{
    public static Boolean CanHitCell(SByte[] cell, Side color)
    {
        throw new NotImplementedException();
        /*for (int i = 0; i < 8; i++)
        for (int j = 0; j < 8; j++)
        {
            if (color == Side.White)
            {
                return FieldNameSpace.Field.SingleField.Table[i,j] switch
                {
                    FigureNames.BishopW=>false
                }
            }
        }
        */
    }
}