using System.Dynamic;
using Fig=FiguresNameSpace.Figures;
namespace FieldNameSpace;

public class Field
{
    //public static Field SingleField { get; private set; }
    public Fig[,] Table { get; set; }

    /*
    static Field()
    {
        SingleField = new Field();
    }
    public void Generate(Fig[,] table)
    {
        SingleField.Table = table;
    }*/
    private Field(Fig[,] table)
    {
        Table = table;
        exists = true;
    }
    private static bool exists = false;
    public static Field Create(Fig[,] table)
    {
        if (!exists) return new Field(table);
        else throw new Exception();
    }
}