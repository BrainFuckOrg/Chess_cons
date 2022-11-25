using FiguresNameSpace;
using IsEndNameSpace;

namespace GameLoopNameSpace;

public static class GameLoop
{
    private static char[] _allowedletters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
    private static char[] _allowednumbers = { '1', '2', '3', '4', '5', '6', '7', '8' };
    public static void Loop()
    {
        bool whiteMove = true;
        while (true)
        {
            RenderingNameSpace.Rendering.ShowField();
            if(IsEndNameSpace.IsEnd.End())break;
            Console.WriteLine(whiteMove ? "White move:" : "Black move:");
            whiteMove = !whiteMove;
            goto1:
            string code = Console.ReadLine();
            if (code.Length == 5&&CheckString(code)&&(whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[1]),Array.IndexOf(_allowedletters,code[0])]==FigureNames.PawnB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[1]),Array.IndexOf(_allowedletters,code[0])]==FigureNames.PawnW))
            {
                bool b = Figure.Pawn.CheckAndMove(
                    new SByte[]
                    {
                        (SByte)Array.IndexOf(_allowednumbers, code[1]), (SByte)Array.IndexOf(_allowedletters, code[0])
                    },
                    new sbyte[]
                    {
                        (SByte)Array.IndexOf(_allowednumbers, code[4]), (SByte)Array.IndexOf(_allowedletters, code[3])
                    });
                if (!b)
                {
                    Console.WriteLine("Invalid move, try again");
                    goto goto1;
                }
            }
            else if(code.Length==6&&CheckString(code.Substring(1,5)))
            {
                bool b = code[0] switch
                {
                    'N' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.KnightB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.KnightW)&&Figure.Knight.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(_allowednumbers, code[2]),(SByte)Array.IndexOf(_allowedletters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(_allowednumbers,code[5]),(SByte)Array.IndexOf(_allowedletters,code[4])}),
                    'B' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.BishopB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.BishopW)&&Figure.Bishop.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(_allowednumbers, code[2]),(SByte)Array.IndexOf(_allowedletters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(_allowednumbers,code[5]),(SByte)Array.IndexOf(_allowedletters,code[4])}),
                    'R' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.RookB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.RookW)&&Figure.Rock.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(_allowednumbers, code[2]),(SByte)Array.IndexOf(_allowedletters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(_allowednumbers,code[5]),(SByte)Array.IndexOf(_allowedletters,code[4])}),
                    'K' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.KingB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.KingW)&&Figure.King.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(_allowednumbers, code[2]),(SByte)Array.IndexOf(_allowedletters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(_allowednumbers,code[5]),(SByte)Array.IndexOf(_allowedletters,code[4])}),
                    'Q' => (whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.QueenB||!whiteMove&&FieldNameSpace.Field.SingleField.Table[Array.IndexOf(_allowednumbers,code[2]),Array.IndexOf(_allowedletters,code[1])]==FigureNames.QueenW)&&Figure.Queen.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(_allowednumbers, code[2]),(SByte)Array.IndexOf(_allowedletters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(_allowednumbers,code[5]),(SByte)Array.IndexOf(_allowedletters,code[4])}),
                    _=>false
                };
                if (!b)
                {
                    Console.WriteLine("Invalid move, try again");
                    goto goto1;
                }
            }
            else
            {
                Console.WriteLine("Wrong coordinates, try again");
                goto goto1;
            }
        }
    }

    private static bool CheckString(string code)
    {
        return _allowedletters.Contains(code[0]) && _allowednumbers.Contains(code[1]) && code[2] == '-' &&
            _allowedletters.Contains(code[3]) && _allowednumbers.Contains(code[4]);
    }
}