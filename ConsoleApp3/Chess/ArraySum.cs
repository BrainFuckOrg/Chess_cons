namespace ArraySumNameSpace;

public static class ArraySum
{
    public static SByte[] sum(SByte[] first, SByte[] second)
    {
        SByte[] newArr = new SByte[first.Length];
        for (Int16 i = 0; i<first.Length; i++)
        {
            newArr[i] = (SByte)(first[i] + second[i]);
        }

        return newArr;
    }
}