using ArraySumNameSpace;
using ConsoleApp3;
using ConsoleApp3.Gameplay;
using FieldNameSpace;
using FiguresNameSpace;

namespace Figure;



public static class Castling
{
    public static List<CastleType> WhiteCastle = new List<CastleType>{ CastleType.Short, CastleType.Long };
    public static List<CastleType> BlackCastle = new List<CastleType>{ CastleType.Short, CastleType.Long };
    private static SByte[] BlackKing = { 7, 4 };
    private static SByte[] WhiteKing = { 0, 4 };
    
    
    public static Boolean CheckAndMove(CastleType type, Side side)
    {
        return side switch
        {
            Side.White => WhiteCastleMove(type),
            Side.Black => BlackCastleMove(type),
            _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
        };
    }

    private static Boolean BlackCastleMove(CastleType type)
    {
        return type switch
        {
            CastleType.Short => BlackCastleMoveShort(),
            CastleType.Long => BlackCastleMoveLong(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    private static Boolean IsHitFields(SByte[] from, SByte[] to, Side color)
    {
        if (CanHit.CanHitCell(from, color)) return true;
        SByte[] SumedCheckCoors = { (SByte)(from[0] - to[0]), (SByte)(from[1] - to[1]) };

        SByte numOfIterations = Math.Max(Math.Abs(SumedCheckCoors[0]), Math.Abs(SumedCheckCoors[1]));
        if (SumedCheckCoors[0] != 0 && SumedCheckCoors[1] != 0)
        {
            SumedCheckCoors[1] = (SByte)(SumedCheckCoors[1] < 0 ? 1 : -1);
            SumedCheckCoors[0] = (SByte)(SumedCheckCoors[0] < 0 ? 1 : -1);
        }
        else
        {
            if (SumedCheckCoors[0] == 0) SumedCheckCoors[1] = (SByte)(SumedCheckCoors[1] < 0 ? 1 : -1);
            else SumedCheckCoors[0] = (SByte)(SumedCheckCoors[0] < 0 ? 1 : -1);
        }

        SByte[] newArr = (SByte[])from.Clone();
        for (SByte i = 0; i < numOfIterations; i++)
        {
            newArr = ArraySum.sum(newArr, SumedCheckCoors); 
            if (CanHit.CanHitCell(newArr, color)) return true;
        }

        return false;
    }

    private static Boolean BlackCastleMoveShort()
    {
        if (IsHitFields(BlackKing, new SByte[] { 7, 6 },Side.White)) return false;
        SByte[] rookPos = { 7, 7 };
        if (!BlackCastle.Contains(CastleType.Short)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(BlackKing, rookPos)) return false;
        GeneralFigureMethods.MoveFigureFromTo(BlackKing, new SByte[] { 7, 6 });
        GeneralFigureMethods.MoveFigureFromTo(rookPos, new SByte[] { 7, 5 });
        MoveCounter.move();
        return true;
    }

    private static Boolean BlackCastleMoveLong()
    {        
        if (IsHitFields(BlackKing, new SByte[] { 7, 2 },Side.White)) return false;
        SByte[] rookPos = { 7, 0 };
        if (!BlackCastle.Contains(CastleType.Long)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(BlackKing, rookPos)) return false;
        GeneralFigureMethods.MoveFigureFromTo(BlackKing, new SByte[] { 7, 2 });
        GeneralFigureMethods.MoveFigureFromTo(rookPos, new SByte[] { 7, 3 });
        MoveCounter.move();
        return true;
    }

    private static Boolean WhiteCastleMove(CastleType type)
    {
        return type switch
        {
            CastleType.Short => WhiteCastleMoveShort(),
            CastleType.Long => WhiteCastleMoveLong(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }

    private static Boolean WhiteCastleMoveShort()
    {        
        if (IsHitFields(WhiteKing, new SByte[] { 0, 6 },Side.Black)) return false;
        SByte[] rookPos = { 0, 7 };
        if (!WhiteCastle.Contains(CastleType.Short)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(WhiteKing, rookPos)) return false;
        GeneralFigureMethods.MoveFigureFromTo(WhiteKing, new SByte[] { 0, 6 });
        GeneralFigureMethods.MoveFigureFromTo(rookPos, new SByte[] { 0, 5 });
        MoveCounter.move();
        return true;
    }

    private static Boolean WhiteCastleMoveLong()
    {        
        if (IsHitFields(WhiteKing, new SByte[] { 0, 2 },Side.Black)) return false;
        SByte[] rookPos = { 0, 0 };
        if (!WhiteCastle.Contains(CastleType.Long)) return false;
        if (GeneralFigureMethods.HasAnotherFigureInMoveLine(WhiteKing, rookPos)) return false;
        GeneralFigureMethods.MoveFigureFromTo(WhiteKing, new SByte[] { 0, 2 });
        GeneralFigureMethods.MoveFigureFromTo(rookPos, new SByte[] { 0, 3 });
        MoveCounter.move();
        return true;
    }

    public static void RookMove(SByte[] from)
    {
        switch (from[0])
        {
            case 7 when from[1] == 7:
                BlackCastle.Remove(CastleType.Short);
                break;
            case 7 when from[1] == 0:
                BlackCastle.Remove(CastleType.Long);
                break;
            case 0 when from[1] == 7:
                WhiteCastle.Remove(CastleType.Short);
                break;
            case 0 when from[1] == 0:
                WhiteCastle.Remove(CastleType.Long);
                break;
        }
    }
    
    public static void KingMove(SByte[] from)
    {
        switch (from[0])
        {
            case 7 when from[1] == 4:
                BlackCastle.Remove(CastleType.Short);
                BlackCastle.Remove(CastleType.Long);
                break;
            case 0 when from[1] == 4:
                WhiteCastle.Remove(CastleType.Short);
                WhiteCastle.Remove(CastleType.Long);
                break;
        }
    }
}