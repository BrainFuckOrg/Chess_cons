using FiguresNameSpace;

namespace RenderingNameSpace;

public static class Rendering
{
    private static Dictionary<FigureNames, Char> _figureRender = new Dictionary<FigureNames, Char>();
    private static ConsoleColor _background = Console.ForegroundColor;
    private static ConsoleColor _foreground = Console.ForegroundColor;
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
        _figureRender.Add(FigureNames.PawnW, '♟');
        _figureRender.Add(FigureNames.BishopW, '♝');
        _figureRender.Add(FigureNames.KnightW, '♞');
        _figureRender.Add(FigureNames.RockW, '♜');
        _figureRender.Add(FigureNames.KingW, '♚');
        _figureRender.Add(FigureNames.QueenW, '♛');
        _figureRender.Add(FigureNames.PawnB, '♟');
        _figureRender.Add(FigureNames.BishopB, '♝');
        _figureRender.Add(FigureNames.KnightB, '♞');
        _figureRender.Add(FigureNames.RockB, '♜');
        _figureRender.Add(FigureNames.KingB, '♚');
        _figureRender.Add(FigureNames.QueenB, '♛');
        _figureRender.Add(FigureNames.Empty, ' ');
    }

    public static void ShowField()
    {
        Console.WriteLine("  a b c d e f g h");
        for (int i = 7; i >= 0; i--)
        {
            Console.BackgroundColor = _background;
            Console.ForegroundColor = _foreground;
            Console.Write((i+1)+" ");
            for (int j = 0; j < 8; j++)
            {
                Console.BackgroundColor = (i + j) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                Console.ForegroundColor = FiguresNameSpace.Figure.WhiteFigures.Contains(FieldNameSpace.Field.SingleField.Table[i,j]) ? ConsoleColor.White : ConsoleColor.Black;
                Console.Write(_figureRender[FieldNameSpace.Field.SingleField.Table[i,j]]+" ");
            }

            Console.BackgroundColor = _background;
            Console.WriteLine();
        }

        Console.ForegroundColor = _foreground;
        Console.BackgroundColor = _background;
        
    }
}