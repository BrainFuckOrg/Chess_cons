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
        for (SByte i = 0; i < 8; i++)
        for (SByte j = 0; j < 8; j++)
        {
            if (color == Side.White)
            {
                return FieldNameSpace.Field.SingleField.Table[i, j] switch
                {
                    FigureNames.BishopW => Bishop.BishopCanMove(new[] { i, j }, cell),
                    FigureNames.KnightW => Knight.KnightCanMove(new[] { i, j }, cell),
                    FigureNames.RookW => Rook.RookCanMove(new[] { i, j }, cell),
                    FigureNames.QueenW => Queen.QueenCanMove(new[] { i, j }, cell),
                    FigureNames.PawnW => Pawn.PawnCanMove(new[] { i, j }, cell),
                    FigureNames.KingW => King.KingCanMove(new[] { i, j }, cell),
                };
            }
            else
            {
                return FieldNameSpace.Field.SingleField.Table[i, j] switch
                {
                    FigureNames.BishopB => Bishop.BishopCanMove(new[] { i, j }, cell),
                    FigureNames.KnightB => Knight.KnightCanMove(new[] { i, j }, cell),
                    FigureNames.RookB => Rook.RookCanMove(new[] { i, j }, cell),
                    FigureNames.QueenB => Queen.QueenCanMove(new[] { i, j }, cell),
                    FigureNames.PawnB => Pawn.PawnCanMove(new[] { i, j }, cell),
                    FigureNames.KingB => King.KingCanMove(new[] { i, j }, cell),
                };
            }
        }
        return false;
    }
}