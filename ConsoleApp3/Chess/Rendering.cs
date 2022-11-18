using FiguresNameSpace;

namespace RenderingNameSpace;

public static class Rendering
{
    private static Dictionary<Figures, Char> _figureRender = new Dictionary<Figures, Char>();

    static Rendering()
    {
        SetFigureRendering();
    }

    private static void SetFigureRendering()
    {
        /*_figureRender.Add(Figures.PawnW, '♙');
        _figureRender.Add(Figures.BishopW, '♗');
        _figureRender.Add(Figures.KnightW, '♘');
        _figureRender.Add(Figures.RockW, '♖');
        _figureRender.Add(Figures.KingW, '♔');
        _figureRender.Add(Figures.QueenW, '♕');*/
        _figureRender.Add(Figures.PawnW, '♟');
        _figureRender.Add(Figures.BishopW, '♝');
        _figureRender.Add(Figures.KnightW, '♞');
        _figureRender.Add(Figures.RockW, '♜');
        _figureRender.Add(Figures.KingW, '♚');
        _figureRender.Add(Figures.QueenW, '♛');
        _figureRender.Add(Figures.PawnB, '♟');
        _figureRender.Add(Figures.BishopB, '♝');
        _figureRender.Add(Figures.KnightB, '♞');
        _figureRender.Add(Figures.RockB, '♜');
        _figureRender.Add(Figures.KingB, '♚');
        _figureRender.Add(Figures.QueenB, '♛');
        _figureRender.Add(Figures.Empty, ' ');
    }

    public static void ShowField(Figures[,] table)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.BackgroundColor = (i + j) % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.Yellow;
                Console.ForegroundColor = Chess.MainClass.WhiteFigures.Contains(table[i,j]) ? ConsoleColor.White : ConsoleColor.Black;
                Console.Write(" "+_figureRender[table[i,j]]+" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
    
}