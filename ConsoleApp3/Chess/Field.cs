using System.Dynamic;
using Fig=FiguresNameSpace.Figures;
namespace FieldNameSpace;

public class Field
{
    public static Field SingleField { get; private set; }
    public Fig[,] Table { get; set; }
    private Field(Fig[,] table)
    {
        Table = table;
        exists = true;
    }
    private static bool exists = false;
    public static void Create(Fig[,] table)
    {
        if (!exists) SingleField= new Field(table);
        else throw new Exception();
    }
}