using FiguresNameSpace;

namespace Chess
{
    public static class MainClass
    {
        public static Figures[] WhiteFigures { get; private set; }
        public static Figures[] BlackFigures { get; private set; }

        static MainClass()
        {
            WhiteFigures=new []{ Figures.BishopW, Figures.KingW, Figures.KnightW, Figures.PawnW, Figures.QueenW, Figures.RockW };
            BlackFigures=new []{ Figures.BishopB, Figures.KingB, Figures.KnightB, Figures.PawnB, Figures.QueenB, Figures.RockB };
        }
        public static void Main()
        {
            GameStartNameSpace.GameStart.NewGame();
        }
    }
}