using FiguresNameSpace;
using GameLoopNameSpace;

namespace JournalNamespace;

public static class Journal
{
    public static List<string> WhiteMoves { get; set; }
    public static List<string> BlackMoves { get; set; }

    static Journal()
    {
        WhiteMoves = new List<string>();
        BlackMoves = new List<string>();
    }

    public static void GetLastMove(out FiguresNameSpace.FigureNames figure, out SByte[] startCoordinates, out SByte[] endCoordinates)
    {
        string code=WhiteMoves.Count > BlackMoves.Count?WhiteMoves[^1]:BlackMoves[^1];
        if (code.Length == 5)
        {
            figure = WhiteMoves.Count > BlackMoves.Count?FiguresNameSpace.FigureNames.PawnW:FigureNames.PawnB;
            startCoordinates = new[]
            {
                (SByte)Array.IndexOf(GameLoop.AllowedNumbers, code[1]),
                (SByte)Array.IndexOf(GameLoop.AllowedLetters, code[0])
            };
            endCoordinates = new[]
            {
                (SByte)Array.IndexOf(GameLoop.AllowedNumbers, code[4]),
                (SByte)Array.IndexOf(GameLoop.AllowedLetters, code[3])
            };
            
        }else
        {
            figure = code[0] switch
            {
                'N' => WhiteMoves.Count > BlackMoves.Count?FigureNames.KnightW:FigureNames.KnightB,
                'B' => WhiteMoves.Count > BlackMoves.Count?FigureNames.BishopW:FigureNames.BishopB,
                'R' => WhiteMoves.Count > BlackMoves.Count?FigureNames.RookW:FigureNames.RookB,
                'Q' => WhiteMoves.Count > BlackMoves.Count?FigureNames.QueenW:FigureNames.QueenB,
                'K' => WhiteMoves.Count > BlackMoves.Count?FigureNames.KingW:FigureNames.KingB
            };
            startCoordinates = new[]
            {
                (SByte)Array.IndexOf(GameLoop.AllowedNumbers, code[2]),
                (SByte)Array.IndexOf(GameLoop.AllowedLetters, code[1])
            };
            endCoordinates = new[]
            {
                (SByte)Array.IndexOf(GameLoop.AllowedNumbers, code[5]),
                (SByte)Array.IndexOf(GameLoop.AllowedLetters, code[4])
            };
        }
        
    }
}