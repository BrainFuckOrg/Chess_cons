using Fig=FiguresNameSpace.Figures;
namespace FieldNameSpace;

public class Field
{
    public Fig[,] Table { get; set; }

    public Field(Fig[,] field)
    {
        Table = field;
    }
}