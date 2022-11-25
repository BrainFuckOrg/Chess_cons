using FieldNameSpace;
using GameLoopNameSpace;

namespace GameStartNameSpace;

public static class GameStart
{
    public static void NewGame()
    {
        //FieldNameSpace.Field field = new Field(GeneratorNameSpace.Generator.Generate());
        Field.Create(GeneratorNameSpace.Generator.Generate());
        GameLoop.Loop();
    }
}