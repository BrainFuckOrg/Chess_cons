using System.Dynamic;
using ConsoleApp3.Loger;
using FiguresNameSpace;

namespace FieldNameSpace;

public class Field
{
    public static Field SingleField { get; private set; }
    private static FigureNames[,] _checkPoint=new FigureNames[8,8];
    public FigureNames[,] Table { get; set; }
    private Field(FigureNames[,] table)
    {
        Table = table;
        exists = true;
    }
    private static bool exists = false;
    public static void Create(FigureNames[,] table)
    {
        LogWritter.Logging("call: Create(...)");
        if (!exists) SingleField= new Field(table);
        else throw new Exception();
    }
    
    public static void CreateCheckPoint()
    {
        LogWritter.Logging("call: CreateCheckPoint()");
        Array.Copy(SingleField.Table,_checkPoint,64);
    }

    public static void Rollback()
    {
        LogWritter.Logging("call: Rollback()");
        Array.Copy(_checkPoint,SingleField.Table,64);
    }
}