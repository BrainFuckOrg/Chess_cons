using System.Dynamic;
using ConsoleApp3.Gameplay;
using ConsoleApp3.Loger;
using Figure;
using FiguresNameSpace;

namespace FieldNameSpace;

public class Field
{
    private static Int16 _countBackup;
    private static List<CastleType> _castleTypesW;
    private static List<CastleType> _castleTypesB;
    static Field()
    {
        Backup = new List<FigureNames[,]>();
    }
    public static List<FigureNames[,]> Backup { get; }
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
        //LogWritter.Logging("call: Create(...)");
        if (!exists) SingleField= new Field(table);
        else throw new Exception();
    }
    
    public static void CreateCheckPoint()
    {
        //LogWritter.Logging("call: CreateCheckPoint()");
        _countBackup = MoveCounter.count;
        _castleTypesW = new List<CastleType>();
        foreach (CastleType c in Castling.WhiteCastle)
        {
            _castleTypesW.Add(c);
        }

        _castleTypesB = new List<CastleType>();
        foreach (CastleType c in Castling.BlackCastle)
        {
            _castleTypesB.Add(c);
        }
        Array.Copy(SingleField.Table,_checkPoint,64);
    }
    public static void CreateBackup()
    {
        LogWritter.Logging("call: CreateBackup()");
        FigureNames[,] b = new FigureNames[8, 8];
        Array.Copy(SingleField.Table,b,64);
        Backup.Add(b);
        CheckRepeats();
    }

    private static void CheckRepeats()
    {
        int count = 0;
        for (int i = Backup.Count - 2; i >= 0; i--)
        {
            bool check = true;
            for(int x=0; x<8; x++)
            for (int y = 0; y < 8; y++)
            {
                check &= Backup[^1][x,y] == Backup[i][x,y];
            }
            if (check) count++;
        }

        if (count > 1)
        {
            IsEndNameSpace.IsEnd.End = true;
            GameLoopNameSpace.GameLoop.gameEndMode = "Treefold";
        }
    }
    public static void Rollback()
    {
        //LogWritter.Logging("call: Rollback()");
        MoveCounter.count = _countBackup;
        //_countBackup = MoveCounter.count;
        Castling.WhiteCastle = new List<CastleType>();
        foreach (CastleType c in _castleTypesW)
        {
            Castling.WhiteCastle.Add(c);
        }

        Castling.BlackCastle = new List<CastleType>();
        foreach (CastleType c in _castleTypesB)
        {
            Castling.BlackCastle.Add(c);
        }
        Array.Copy(_checkPoint,SingleField.Table,64);
    }
}