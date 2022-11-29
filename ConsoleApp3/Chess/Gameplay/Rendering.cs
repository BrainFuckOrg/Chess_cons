using FiguresNameSpace;
using System.Collections.Generic;

namespace RenderingNameSpace;

public static class Rendering
{
    
    private static Dictionary<FigureNames, Char> _figureRender = new Dictionary<FigureNames, Char>();
    static Rendering()
    {
        SetFigureRendering();
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
        int position = JournalNamespace.Journal.WhiteMoves.Count - 8-moveUp;
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
            if(JournalNamespace.Journal.WhiteMoves.Count>8&&i==7)Console.Write("           ...");
            else if(JournalNamespace.Journal.WhiteMoves.Count>8&&i==0&&position!=JournalNamespace.Journal.WhiteMoves.Count-1)Console.Write("           ...");
            else{
                if (position < JournalNamespace.Journal.WhiteMoves.Count) Console.Write("  {0,4} {1,6}", position + 1, JournalNamespace.Journal.WhiteMoves[position]);
                if (position < JournalNamespace.Journal.BlackMoves.Count) Console.Write("  {0,6}", JournalNamespace.Journal.BlackMoves[position]);
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