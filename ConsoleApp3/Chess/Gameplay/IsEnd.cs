using System.Runtime.InteropServices.ComTypes;
using ConsoleApp3;
using Figure;
using FiguresNameSpace;

namespace IsEndNameSpace;

public static class IsEnd
{
    public static Boolean End { get; set; }

    static IsEnd()
    {
        End = false;
    }
    public static Boolean CheckEnd(SByte[] from)
    {
        FigureNames[,] Table = FieldNameSpace.Field.SingleField.Table;
        if (FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0],from[1]]))
        {
            return CheckEnd(Side.Black);
        }

        return CheckEnd(Side.White);
    }
    private static bool CheckEnd(Side side)
    {
        for (SByte i = 0; i < 8; i++)
        {
            for (SByte j = 0; j < 8; j++)
            {
                for (SByte i2 = 0; i2 < 8; i2++)
                {
                    for (SByte j2 = 0; j2 < 8; j2++)
                    {
                        FieldNameSpace.Field.CreateCheckPoint();
                        if (side == Side.White)
                        {
                            switch (FieldNameSpace.Field.SingleField.Table[i, j])
                            {
                                case FigureNames.BishopB: Bishop.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.KingB: King.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.KnightB: Knight.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.PawnB: Pawn.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.QueenB: Queen.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.RookB: Rook.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                            }
                        }
                        else
                        {
                            switch (FieldNameSpace.Field.SingleField.Table[i, j])
                            {
                                case FigureNames.BishopW: Bishop.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.KingW: King.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.KnightW: Knight.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.PawnW: Pawn.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.QueenW: Queen.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                                case FigureNames.RookW: Rook.CheckAndMove(new[] { i, j }, new[] { i2, j2 });
                                    break;
                            }
                        }

                        if (!GeneralFigureMethods.IsKingChecked(side))
                        {
                            FieldNameSpace.Field.Rollback();
                            return false;
                        }
                        FieldNameSpace.Field.Rollback();
                    }
                }
            }
        }
        End = true;
        return true;
    }
}