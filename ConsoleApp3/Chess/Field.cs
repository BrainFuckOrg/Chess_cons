using System.Dynamic;
using FiguresNameSpace;

namespace FieldNameSpace;

public class Field
{
    public static Field SingleField { get; private set; }
    public FigureNames[,] Table { get; set; }
    private Field(FigureNames[,] table)
    {
        Table = table;
        exists = true;
    }
    private static bool exists = false;
    public static void Create(FigureNames[,] table)
    {
        if (!exists) SingleField= new Field(table);
        else throw new Exception();
    }
}