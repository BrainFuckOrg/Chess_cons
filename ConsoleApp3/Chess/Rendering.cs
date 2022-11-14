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
        _figureRender.Add(Figures.PawnW, '♙');
        _figureRender.Add(Figures.BishopW, '♗');
        _figureRender.Add(Figures.KnightW, '♘');
        _figureRender.Add(Figures.RockW, '♖');
        _figureRender.Add(Figures.KingW, '♔');
        _figureRender.Add(Figures.QueenW, '♕');
        _figureRender.Add(Figures.PawnB, '♟');
        _figureRender.Add(Figures.BishopB, '♝');
        _figureRender.Add(Figures.KnightB, '♞');
        _figureRender.Add(Figures.RockB, '♜');
        _figureRender.Add(Figures.KingB, '♚');
        _figureRender.Add(Figures.QueenB, '♛');

    }

    public static void ShowField(Figures[,] table)
    {
        
    }
    
}