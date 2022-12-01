using ConsoleApp3;
using FieldNameSpace;
using FiguresNameSpace;
using GameLoopNameSpace;

namespace Figure;

public static class Pawn
{
    public static Boolean CheckAndMove(SByte[] from, SByte[] to)
    {
        if (!PawnCanMove(from, to)) return false;
        if(isEnPassant(from,to)) removePassantPawn();
        GeneralFigureMethods.MoveFigureFromTo(from,to);
        
        checkIfTheLastLine(to);
        return true;
    }

    public static Boolean PawnCanMove(SByte[] from, SByte[] to)
    {
        if (!(isThisFigureMove(from, to) || isPawnTake(from, to))) return false;
        if (GeneralFigureMethods.HasAnotherThisColorFigure(from, to)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(from, to)) return false;
        return true;
    }
    private static Boolean isThisFigureMove(SByte[] from, SByte[] to)
    {
        if (from[1] != to[1]) return false;
        FigureNames[,] Table = Field.SingleField.Table;
        if (Table[to[0], to[1]] != FigureNames.Empty) return false;
        return Table[from[0], from[1]] switch
        {
            FigureNames.PawnB => from[0] - to[0] == 1 || (from[0] == 6 && from[0] - to[0] == 2),
            FigureNames.PawnW => from[0] - to[0] == -1 || (from[0] == 1 && from[0] - to[0] == -2),
            _ => false
        };
    }
    
    private static Boolean isPawnTake(SByte[] from, SByte[] to)
    {
        if (isEnPassant(from, to)) return true;
        FigureNames[,] Table = Field.SingleField.Table;
        if (Table[to[0], to[1]] == FigureNames.Empty) return false;
        return Table[from[0], from[1]] switch
        {
            FigureNames.PawnB => from[0] - to[0] == 1 && Math.Abs(from[1]-to[1])==1,
            FigureNames.PawnW => from[0] - to[0] == -1 && Math.Abs(from[1]-to[1])==1,
            _ => false
        };
    }

    private static Boolean isEnPassant(SByte[] from, SByte[] to)
    {
        FigureNames[,] Table = Field.SingleField.Table;
        if (Table[to[0], to[1]] != FigureNames.Empty) return false;
        if (Math.Abs(from[1] - to[1]) != 1) return false;
        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0],from[1]]))
        {
            return BlackEnPassant(from, to);
        }

        return WhiteEnPassant(from, to);
    }

    private static void removePassantPawn()
    {
        FigureNames[,] Table = Field.SingleField.Table;
        FigureNames figure;
        SByte[] startCoordinates;
        SByte[] endCoordinates;
        JournalNamespace.Journal.GetLastMove(out figure, out startCoordinates, out endCoordinates);
        Table[endCoordinates[0], endCoordinates[1]] = FigureNames.Empty;
    }

    private static Boolean WhiteEnPassant(SByte[] from, SByte[] to)
    {
        FigureNames figure;
        SByte[] startCoordinates;
        SByte[] endCoordinates;
        JournalNamespace.Journal.GetLastMove(out figure, out startCoordinates, out endCoordinates);
        if (figure != FigureNames.PawnB) return false;
        if (startCoordinates[0] == 6 && endCoordinates[0] == 4 && startCoordinates[1] == to[1] &&
            to[0] == 5) return true;
        return false;
    }

    private static Boolean BlackEnPassant(SByte[] from, SByte[] to)
    {        
        FigureNames figure;
        SByte[] startCoordinates;
        SByte[] endCoordinates;
        JournalNamespace.Journal.GetLastMove(out figure, out startCoordinates, out endCoordinates);
        if (figure != FigureNames.PawnW) return false;
        if (startCoordinates[0] == 1 && endCoordinates[0] == 3 && startCoordinates[1] == to[1] &&
            to[0] == 2) return true;
        return false;
    }

    private static void checkIfTheLastLine(SByte[] to)
    {
        if (!(to[0]==0 || to[0]==7)) return;
        
        FigureNames[,] Table = Field.SingleField.Table;
        Table[to[0],to[1]] = GameLoop.AskPawnTransformation();
    }
}