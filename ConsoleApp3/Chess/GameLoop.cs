namespace GameLoopNameSpace;

public static class GameLoop
{
    public static void Loop(FieldNameSpace.Field field)
    {
        while (true)
        {
            RenderingNameSpace.Rendering.ShowField(field.Table);
            break;
        }
    }
}