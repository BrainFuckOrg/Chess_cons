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
            if (code.Length == 5&&CheckString(code))
            {
                
            }
            else if(code.Length==6&&CheckString(code.Substring(1,5)))
            {
                bool b = code[0] switch
                {
                    'N' => Figure.Knight.CheckAndMove(new SByte[] { (SByte)Array.IndexOf(_allowednumbers, code[2]),(SByte)Array.IndexOf(_allowedletters,code[1]) },new sbyte[]{(SByte)Array.IndexOf(_allowednumbers,code[5]),(SByte)Array.IndexOf(_allowedletters,code[4])})
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