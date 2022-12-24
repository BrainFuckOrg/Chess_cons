namespace ConsoleApp3.Gameplay;

public class MoveCounter
{
    private static Int16 count = 0;
    private static readonly Int16 drawNumber = 50;
    
    public static void move()
    {
        count++;
    }

    public static void nullable()
    {
        count = 0;
    }

    public static Boolean isEnd()
    {
        return count == drawNumber * 2;
    }
}