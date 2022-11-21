using FiguresNameSpace;

namespace Chess
{
    public static class MainClass
    {
        public static FigureNames[] WhiteFigures { get; private set; }
        public static FigureNames[] BlackFigures { get; private set; }

        static MainClass()
        {
            WhiteFigures=new []{ FigureNames.BishopW, FigureNames.KingW, FigureNames.KnightW, FigureNames.PawnW, FigureNames.QueenW, FigureNames.RockW };
            BlackFigures=new []{ FigureNames.BishopB, FigureNames.KingB, FigureNames.KnightB, FigureNames.PawnB, FigureNames.QueenB, FigureNames.RockB };
        }
        public static void Main()
        {
            GameStartNameSpace.GameStart.NewGame();
        }
    }
}