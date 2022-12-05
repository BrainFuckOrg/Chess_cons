namespace ConsoleApp3.Loger;

public static class LogWritter
{
    private static String path1 = "LogInfo";
    
    static LogWritter()
    {
        FileStream fs = new FileStream(path1, FileMode.OpenOrCreate);
        fs.Close();
        Logging("________________________________");
    }

    public static void Logging(String info)
    {
        StreamWriter sw = new StreamWriter(path1, true);
        sw.WriteLine(info);
        sw.Close();
    }
}