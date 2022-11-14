using FieldNameSpace;

namespace GameStartNameSpace;

public static class GameStart
{
    public static void NewGame()
    {
        FieldNameSpace.Field field = new Field(GeneratorNameSpace.Generator.Generate());
    }
}