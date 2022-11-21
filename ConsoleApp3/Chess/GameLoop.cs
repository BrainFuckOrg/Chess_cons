using IsEndNameSpace;

namespace GameLoopNameSpace;

public static class GameLoop
{
    public static void Loop()
    {
        while (true)
        {
            RenderingNameSpace.Rendering.ShowField();
            if(IsEndNameSpace.IsEnd.End())break;
            
        }
    }
}