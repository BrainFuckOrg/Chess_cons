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