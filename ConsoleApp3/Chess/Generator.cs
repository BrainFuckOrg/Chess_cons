using FiguresNameSpace;

namespace GeneratorNameSpace;

public static class Generator
{
    private static FigureNames[] LastLineW = {FigureNames.RockW, FigureNames.KnightW,FigureNames.BishopW,FigureNames.QueenW,FigureNames.KingW,FigureNames.BishopW,FigureNames.KnightW,FigureNames.RockW};
    private static FigureNames[] LastLineB = {FigureNames.RockB, FigureNames.KnightB,FigureNames.BishopB,FigureNames.QueenB,FigureNames.KingB,FigureNames.BishopB,FigureNames.KnightB,FigureNames.RockB};
    public static FigureNames[,] Generate()
    {
        FigureNames[,] field = new FigureNames[8, 8];
        for (int i = 0; i < 8; i++)
        {
            field[0, i] = LastLineW[i];
            field[1, i] = FigureNames.PawnW;
            field[6, i] = FigureNames.PawnB;
            field[7, i] = LastLineB[i];
            for (int j = 2; j < 6; j++) field[j, i] = FigureNames.Empty;
        }
        return field;
    }
}