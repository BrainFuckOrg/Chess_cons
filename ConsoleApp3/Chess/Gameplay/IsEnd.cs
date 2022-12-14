using System.Runtime.InteropServices.ComTypes;
using ConsoleApp3;
using ConsoleApp3.Loger;
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

    public static void CheckPat(Side side)
    {
        //LogWritter.Logging("call: CheckPat("+side+")");
        for (SByte i = 0; i < 8; i++)
        {
            for (SByte j = 0; j < 8; j++)
            {
                for (SByte i2 = 0; i2 < 8; i2++)
                {
                    for (SByte j2 = 0; j2 < 8; j2++)
                    {
                        bool check;
                        FieldNameSpace.Field.CreateCheckPoint();
                        if (side != Side.White)
                        {
                            check = FieldNameSpace.Field.SingleField.Table[i, j] switch
                            {
                                FigureNames.BishopB => Bishop.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.KingB => King.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.KnightB => Knight.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.PawnB => Pawn.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.QueenB => Queen.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.RookB => Rook.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                _=>false
                            };
                        }
                        else
                        {
                            check = FieldNameSpace.Field.SingleField.Table[i, j] switch
                            {
                                FigureNames.BishopW => Bishop.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.KingW => King.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.KnightW => Knight.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.PawnW => Pawn.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.QueenW=> Queen.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                FigureNames.RookW=> Rook.CheckAndMove(new[] { i, j }, new[] { i2, j2 }),
                                _=>false
                            };
                        }

                        if (check)
                        {
                            FieldNameSpace.Field.Rollback();
                            return;
                        }
                    }
                }
            }
        }
        End = true;
        GameLoopNameSpace.GameLoop.gameEndMode = "stalemate";
    }
    public static Boolean CheckEnd(SByte[] from)
    {
        //LogWritter.Logging(String.Format("call: CheckEnd({0},{1})",from[0],from[1]));
        FigureNames[,] Table = FieldNameSpace.Field.SingleField.Table;
        if (!FiguresNameSpace.Figure.BlackFigures.Contains(Table[from[0],from[1]]))
        {
            return CheckEnd(Side.Black);
        }

        return CheckEnd(Side.White);
    }
    private static bool CheckEnd(Side side)
    {
        //LogWritter.Logging("call: CheckEnd("+side+")");
        for (SByte i = 0; i < 8; i++)
        {
            for (SByte j = 0; j < 8; j++)
            {
                for (SByte i2 = 0; i2 < 8; i2++)
                {
                    for (SByte j2 = 0; j2 < 8; j2++)
                    {
                        FieldNameSpace.Field.CreateCheckPoint();
                        if (side != Side.White)
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
        GameLoopNameSpace.GameLoop.gameEndMode = (side==Side.White?"black":"white")+" victory";
        return true;
    }
}