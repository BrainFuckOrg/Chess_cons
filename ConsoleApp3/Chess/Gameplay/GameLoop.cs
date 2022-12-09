using Figure;
using FiguresNameSpace;
using IsEndNameSpace;

namespace GameLoopNameSpace;

public static class GameLoop
{
    private static bool whiteMove = true;
    public static char[] AllowedLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
    public static char[] AllowedNumbers = { '1', '2', '3', '4', '5', '6', '7', '8' };
    private static string _transformHelper;

    
    public static void Loop()
    {
        
        int moveUp = 0;
        string gameEndMode = "";
        while (true)
        {
            moveUp = 0;
            RenderingNameSpace.Rendering.ShowField(moveUp);
            if(IsEndNameSpace.IsEnd.CheckEnd())break;
            Console.WriteLine(whiteMove ? "White move:" : "Black move:");
            whiteMove = !whiteMove;
            goto1:
            string code = Console.ReadLine();
            if (code == "draw")
            {
                gameEndMode = "draw";
                break;
            }
            if (code.Substring(0, 2) == "up")
            {
                moveUp += Convert.ToInt32(code.Substring(3));
                RenderingNameSpace.Rendering.ShowField(moveUp);
                Console.WriteLine(!whiteMove ? "White move:" : "Black move:");
                goto goto1;
            }
            else if (code.Length>5&&code.Substring(0, 4) == "down")
            {
                moveUp -= Convert.ToInt32(code.Substring(5));
                if (moveUp < 0) moveUp = 0;
                RenderingNameSpace.Rendering.ShowField(moveUp);
                Console.WriteLine(!whiteMove ? "White move:" : "Black move:");
                goto goto1;
            }
            else if (code == "0-0")
            {
                if (!Castling.CheckAndMove(CastleType.Short, whiteMove ? Side.Black: Side.White))
                {
                    Console.WriteLine("Short castling impossible");
                    goto goto1;
                }else if (whiteMove) JournalNamespace.Journal.BlackMoves.Add("0-0");
                else JournalNamespace.Journal.WhiteMoves.Add("0-0");
            }else if (code == "0-0-0")
            {
                if (!Castling.CheckAndMove(CastleType.Long, whiteMove ? Side.Black: Side.White))
                {
                    Console.WriteLine("Long castling impossible");
                    goto goto1;
                }else if (whiteMove) JournalNamespace.Journal.BlackMoves.Add("0-0-0");
                else JournalNamespace.Journal.WhiteMoves.Add("0-0-0");
            }
            else if (code.Length == 5&&CheckString(code)&&(whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[1]),Array.IndexOf(AllowedLetters,code[0])]==FigureNames.PawnB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[1]),Array.IndexOf(AllowedLetters,code[0])]==FigureNames.PawnW))
            {
                _transformHelper = "";
                bool b = Figure.Pawn.CheckAndMove(
                    new SByte[]
                    {
                        (SByte)Array.IndexOf(AllowedNumbers, code[1]), (SByte)Array.IndexOf(AllowedLetters, code[0])
                    },
                    new sbyte[]
                    {
                        (SByte)Array.IndexOf(AllowedNumbers, code[4]), (SByte)Array.IndexOf(AllowedLetters, code[3])
                    });
                if (!b)
                {
                    Console.WriteLine("Invalid move, try again");
                    goto goto1;
                }else if (whiteMove)
                {
                    JournalNamespace.Journal.BlackMoves.Add(code+_transformHelper);
                }
                else
                {
                    JournalNamespace.Journal.WhiteMoves.Add(code+_transformHelper);
                }
            }
            else if(code.Length==6&&CheckString(code.Substring(1,5)))
            {
                bool b = code[0] switch
                {
                    'N' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.KnightB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.KnightW)&&Figure.Knight.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(AllowedNumbers, code[2]),(SByte)Array.IndexOf(AllowedLetters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(AllowedNumbers,code[5]),(SByte)Array.IndexOf(AllowedLetters,code[4])}),
                    'B' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.BishopB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.BishopW)&&Figure.Bishop.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(AllowedNumbers, code[2]),(SByte)Array.IndexOf(AllowedLetters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(AllowedNumbers,code[5]),(SByte)Array.IndexOf(AllowedLetters,code[4])}),
                    'R' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.RookB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.RookW)&&Figure.Rook.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(AllowedNumbers, code[2]),(SByte)Array.IndexOf(AllowedLetters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(AllowedNumbers,code[5]),(SByte)Array.IndexOf(AllowedLetters,code[4])}),
                    'K' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.KingB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.KingW)&&Figure.King.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(AllowedNumbers, code[2]),(SByte)Array.IndexOf(AllowedLetters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(AllowedNumbers,code[5]),(SByte)Array.IndexOf(AllowedLetters,code[4])}),
                    'Q' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.QueenB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(AllowedNumbers,code[2]),Array.IndexOf(AllowedLetters,code[1])]==FigureNames.QueenW)&&Figure.Queen.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(AllowedNumbers, code[2]),(SByte)Array.IndexOf(AllowedLetters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(AllowedNumbers,code[5]),(SByte)Array.IndexOf(AllowedLetters,code[4])}),
                    _=>false
                };
                if (!b)
                {
                    Console.WriteLine("Invalid move, try again");
                    goto goto1;
                }else if (whiteMove)
                {
                    JournalNamespace.Journal.BlackMoves.Add(code);
                }
                else
                {
                    JournalNamespace.Journal.WhiteMoves.Add(code);
                }
            }
            else
            {
                Console.WriteLine("Wrong coordinates, try again");
                goto goto1;
            }
        }
        RenderingNameSpace.Rendering.ClearConsole();
        Console.WriteLine("Game ended with "+gameEndMode);
    }

    public static FigureNames AskPawnTransformation()
    {
        Console.WriteLine("transform pawn");
        string code = Console.ReadLine();
        _transformHelper = "(" + code + ")";
        if (whiteMove)
        {
            return code switch
            {
                "N" => FigureNames.KnightB,
                "B" => FigureNames.BishopB,
                "R" => FigureNames.RookB,
                "Q" => FigureNames.QueenB
            };
        }
        else
        {
            return code switch
            {
                "N" => FigureNames.KnightW,
                "B" => FigureNames.BishopW,
                "R" => FigureNames.RookW,
                "Q" => FigureNames.QueenW
            };
        }
    }
    private static bool CheckString(string code)
    {
        return AllowedLetters.Contains(code[0]) && AllowedNumbers.Contains(code[1]) && code[2] == '-' &&
            AllowedLetters.Contains(code[3]) && AllowedNumbers.Contains(code[4]);
    }
}