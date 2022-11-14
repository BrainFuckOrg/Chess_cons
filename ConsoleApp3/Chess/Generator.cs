using Fig=FiguresNameSpace.Figures;
namespace GeneratorNameSpace;

public static class Generator
{
    private static Fig[] LastLineW = {Fig.RockW, Fig.KnightW,Fig.BishopW,Fig.QueenW,Fig.KingW,Fig.BishopW,Fig.KnightW,Fig.RockW};
    private static Fig[] LastLineB = {Fig.RockB, Fig.KnightB,Fig.BishopB,Fig.QueenB,Fig.KingB,Fig.BishopB,Fig.KnightB,Fig.RockB};
    public static Fig[,] Generate()
    {
        Fig[,] field = new Fig[8, 8];
        for (int i = 0; i < 8; i++)
        {
            field[0, i] = LastLineW[i];
            field[1, i] = Fig.PawnW;
            field[6, i] = Fig.PawnB;
            field[7, i] = LastLineB[i];
            for (int j = 2; j < 6; j++) field[j, i] = Fig.Empty;
        }
        return field;
    }
}