using FiguresNameSpace;
using System.Collections.Generic;

namespace RenderingNameSpace;

public static class Rendering
{
    public static List<string> WhiteMoves { get; set; }
    public static List<string> BlackMoves { get; set; }
    private static Dictionary<FigureNames, Char> _figureRender = new Dictionary<FigureNames, Char>();
    static Rendering()
    {
        SetFigureRendering();
        WhiteMoves = new List<string>();
        BlackMoves = new List<string>();
    }

    private static void SetFigureRendering()
    {
        _figureRender.Add(FigureNames.PawnW, '♟');
        _figureRender.Add(FigureNames.BishopW, '♝');
        _figureRender.Add(FigureNames.KnightW, '♞');
        _figureRender.Add(FigureNames.RookW, '♜');
        _figureRender.Add(FigureNames.KingW, '♚');
        _figureRender.Add(FigureNames.QueenW, '♛');
        _figureRender.Add(FigureNames.PawnB, '♟');
        _figureRender.Add(FigureNames.BishopB, '♝');
        _figureRender.Add(FigureNames.KnightB, '♞');
        _figureRender.Add(FigureNames.RookB, '♜');
        _figureRender.Add(FigureNames.KingB, '♚');
        _figureRender.Add(FigureNames.QueenB, '♛');
        _figureRender.Add(FigureNames.Empty, ' ');
    }

    public static void ShowField(int moveUp=0)//TODO pawn transformation in journal
    {
        ClearConsole();
        Console.WriteLine("  a b c d e f g h           w       b");
        int position = WhiteMoves.Count - 8-moveUp;
        if (position < 0) position = 0;
        for (int i = 7; i >= 0; i--)
        {
            Console.ResetColor();
            Console.Write((i+1)+" ");
            for (int j = 0; j < 8; j++)
            {
                Console.BackgroundColor = (i + j) % 2 == 0 ? ConsoleColor.DarkRed : ConsoleColor.Yellow;
                Console.ForegroundColor = FiguresNameSpace.Figure.WhiteFigures.Contains(FieldNameSpace.Field.SingleField.Table[i,j]) ? ConsoleColor.White : ConsoleColor.Black;
                Console.Write(_figureRender[FieldNameSpace.Field.SingleField.Table[i,j]]+" ");
            }
            Console.ResetColor();
            if(WhiteMoves.Count>8&&i==7)Console.Write("           ...");
            else if(WhiteMoves.Count>8&&i==0&&position!=WhiteMoves.Count-1)Console.Write("           ...");
            else{
                if (position < WhiteMoves.Count) Console.Write("  {0,4} {1,6}", position + 1, WhiteMoves[position]);
                if (position < BlackMoves.Count) Console.Write("  {0,6}", BlackMoves[position]);
            }
            position++;
            Console.WriteLine();
        }
    }

    private static void ClearConsole()
    {
        Console.SetCursorPosition(0,0);
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            Console.WriteLine(new String(' ',Console.WindowWidth));
        }
        Console.SetCursorPosition(0,0);
    }
}