namespace GameLoopNameSpace;

public static class GameLoop
{
    public static void Loop()
    {
        while (true)
        {
            RenderingNameSpace.Rendering.ShowField();
            break;
        }
    }
}