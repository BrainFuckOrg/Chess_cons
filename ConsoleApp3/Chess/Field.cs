using Fig=FiguresNameSpace.Figures;
namespace FieldNameSpace;

public class Field
{
    public static Field SingleField { get; private set; }
    public Fig[,] Table { get; set; }

    /*public Field(Fig[,] field)
    {
        Table = field;
    }*/
    static Field()
    {
        SingleField = new Field();
    }
    public void Generate(Fig[,] table)
    {
        SingleField.Table = table;
    }
}