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

    public static void ShowField()
    {
        Console.WriteLine("  a b c d e f g h");
        for (int i = 7; i >= 0; i--)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write((i+1)+" ");
            for (int j = 0; j < 8; j++)
            {
                Console.BackgroundColor = (i + j) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                Console.ForegroundColor = Chess.MainClass.WhiteFigures.Contains(FieldNameSpace.Field.SingleField.Table[i,j]) ? ConsoleColor.White : ConsoleColor.Black;
                Console.Write(_figureRender[FieldNameSpace.Field.SingleField.Table[i,j]]+" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
    
}