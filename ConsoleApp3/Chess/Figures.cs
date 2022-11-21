namespace FiguresNameSpace;

public enum FigureNames
{
    Empty,
    PawnW,
    BishopW,
    KnightW,
    RockW,
    KingW,
    QueenW,
    PawnB,
    BishopB,
    KnightB,
    RockB,
    KingB,
    QueenB
}

public static class Figure
{
    public static readonly FigureNames[] WhiteFigures = { FigureNames.BishopW, FigureNames.KingW, FigureNames.KnightW, FigureNames.PawnW, FigureNames.QueenW, FigureNames.RockW };
    public static readonly FigureNames[] BlackFigures = { FigureNames.BishopB, FigureNames.KingB, FigureNames.KnightB, FigureNames.PawnB, FigureNames.QueenB, FigureNames.RockB };
}